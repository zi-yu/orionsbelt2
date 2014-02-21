using System.Configuration;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using System.IO;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface.Engine {
	public static class ResourcesManager {

		#region Fields

		private static readonly string imagesPath;
		private static readonly string scriptPath;
		private static readonly string stylePath;
		private static readonly string common = "Common";
        private static readonly string intergalactic = "IntergalacticTournament";

		#endregion Fields

		#region Properties

		public static string ImagesPath {
			get {
				return imagesPath;
			}
		}


		public static string ImagesCommonControlDir {
			get {
				if (ImagesCommonPath.IndexOf("http://") == -1) {
					return string.Format("~/{0}", ImagesCommonPath);
				}
				return ImagesCommonPath;
			}
		}

		public static string ImagesUniverseDir {
			get {
				return ImagesCommonControlDir + "/Universe";
			}
		}

		public static string ImagesLocalizedControlDir {
			get {
				if (ImagesLocalizedPath.IndexOf("http://") == -1) {
					return string.Format("~/{0}", ImagesLocalizedPath);
				}
				return ImagesLocalizedPath;
			}
		}

		public static string ImagesCommonPath {
			get { return Combine(imagesPath,common); }
		}

        public static string ImagesIntergalacticPath
        {
            get { return Combine(imagesPath, intergalactic); }
        }

		public static string ImagesLocalizedPath {
			get { return Combine(imagesPath, LanguageManager.CurrentLanguage); }
		}

		public static string ScriptsPath {
			get { return scriptPath; }
		}

        public static string ScriptsVersion {
            get { return ConfigurationManager.AppSettings["scriptVersion"]; }
        }

        public static string StylesPath {
            get { return stylePath; }
        }

		public static string StylesCommonPath {
			get { return Combine(stylePath, common); }
		}

		public static string StylesLocalizedPath {
			get { return Combine(stylePath, LanguageManager.CurrentLanguage); }
		}

		public static string UnitsPath {
			get { return Combine(ImagesCommonPath,"Units"); }
		}

        public static string UnitsPerspectivePath {
			get { return Combine(ImagesCommonPath,"Units/Perspective"); }
		}

        public static string DefaultAvatar {
			get { return Combine(ImagesCommonPath, "Avatar.png"); }
		}

		#endregion Properties

		#region Private

		private static string Combine( string url1, string url2 ) {
			return string.Format("{0}/{1}",url1,url2);
		}

		private static string GetName(IResourceInfo resource) {
			string name;
			if (resource.Type == ResourceType.Unit) {
				name = resource.Name.ToLower();
			} else {
				name = resource.Name;
			}
			return name;
		}

		#endregion

		#region Images

		public static string GetLocalizedImage(string name) {
			return Combine(ImagesLocalizedPath, name);
		}

		public static string GetControlLocalizedImage( string name) {
			return Combine(ImagesLocalizedPath, name);
		}

		public static string GetImage(string name) {
			return Combine(ImagesCommonPath, name);
		}

		public static string GetUnitImage( string name ) {
			string unitName = string.Format("{0}.png", name.ToLower());
			return Combine(UnitsPath, unitName);
		}

        public static string GetUnitPerspectiveImage(string name) {
            string unitName = string.Format("{0}.png", name);
            return Combine(UnitsPerspectivePath, unitName);
        }

		public static string GetUnitImage(IUnitInfo unit) {
			string unitName = string.Format("{0}.png", unit.Name.ToLower());
			return Combine(UnitsPath, unitName);
		}

		public static string GetUnitImage(string name, char position) {
			string unitName = string.Format("{0}_{1}.png", name.ToLower(), position);
			return Combine(UnitsPath, unitName);
		}

		public static string GetUniverseImage(string name) {
			string image = string.Format("Universe/{0}.png", name);
			return Combine(ImagesCommonPath, image);
		}

		public static string GetUniverseDiscoveredImage(string name) {
			string image = string.Format("Universe/{0}d.png", name);
			return Combine(ImagesCommonPath, image);
		}

		public static string GetUniverseImage(string name, string extension) {
			string image = string.Format("Universe/{0}.{1}", name, extension);
			return Combine(ImagesCommonPath, image);
		}

        public static string GetResourceImage(IResourceInfo resource) {
			string image = string.Format("Resources/{0}.png", GetName(resource));
			return Combine(ImagesCommonPath, image);
		}

		public static string GetEtcImage(string name) {
			string image = string.Format("Etc/{0}.gif", name);
			return Combine(ImagesCommonPath, image);
		}

        public static string GetPlanetImage(string name)
        {
            string image = string.Format("Planets/{0}.png", name);
            return Combine(ImagesCommonPath, image);
        }

        public static string GetFacilityImage(IRaceInfo race, IFacilitySlot slot)
        {
            string image = string.Format("Planets/{0}/{1}.png", race.Race, slot.CanBuildImage);
            return Combine(ImagesCommonPath, image);
        }

        public static string GetFacilityImage(IRaceInfo race, IResourceInfo info)
        {
            string image = string.Format("Planets/{0}/{1}R.png", race.Race, info.Name);
            return Combine(ImagesCommonPath, image);
        }

		public static string GetPaymentsImage(string paymentType) {
			string image = string.Format("Payments/{0}.png", paymentType);
			return Combine(ImagesCommonPath, image);
		}


        public static string GetFacilityImage(IRaceInfo race, IPlanetResource resource)
        {
            TextWriter writer = new StringWriter();
            
            writer.Write("Planets/");
            writer.Write(race.Race);
            writer.Write("/");
            writer.Write(resource.Info.Name);
            
            if (resource.State == ResourceState.InQueue) {
                writer.Write("C");
            } else if (resource.State == ResourceState.InConstruction) {
                writer.Write("C");
            } else {
                writer.Write("R");
            }

            writer.Write(".png");

            return Combine(ImagesCommonPath, writer.ToString());
        }

        public static string GetIntergalacticImage(string name)
        {
            return Combine(ImagesIntergalacticPath, name);
        }

		public static string GetMessageImage(IMessage message) {
			string image = string.Format("Messages/{0}/{1}.png", message.Category, message.MessageType);
			return Combine(ImagesCommonPath, image);
		}

        public static string GetForumImage(string imageName)
        {
            string image = string.Format("Messages/Forum/{0}", imageName);
            return Combine(ImagesCommonPath, image);
        }

        public static string GetForumSmilePath(string imageName) {
            string image = string.Format("Messages/Forum/Smilies/{0}.gif", imageName);
            return Combine(ImagesCommonPath, image);
        }

        public static string GetForumSmile(string imageName) {
            string image = string.Format("Messages/Forum/Smilies/{0}.gif", imageName);
            return string.Format("<img src='{0}'/>",Combine(ImagesCommonPath, image));
        }

        public static string GetMedalImage(OrionsBelt.RulesCore.Enum.MedalType medal)
        {
            return GetMedalImage(medal.ToString());
        }

        public static string GetMedalImage(string medal)
        {
            string image = string.Format("Medals/{0}.png", medal);
            return Combine(ImagesCommonPath, image);
        }

		public static string GetBattleImage(string name, string extension) {
			string image = string.Format("Battle/{0}.{1}", name, extension);
			return Combine(ImagesCommonPath, image);
		}

		public static string GetBattleImage(string name) {
			return GetBattleImage(name, "png");
		}

		public static string GetIconsImage(string name) {
			string image = string.Format("Icons/{0}.png", name);
			return Combine(ImagesCommonPath, image);
		}

		public static string GetMobImage(string name) {
			return GetMobImage(name,"png");
		}

		public static string GetMobImage(string name, string extension) {
			string image = string.Format("Mobs/{0}.{1}", name, extension);
			return Combine(ImagesCommonPath, image);
		}

		public static string GetRace(Race race) {
			string image = string.Format("Races/{0}.png", race);
			return Combine(ImagesCommonPath, image);
		}

		public static string GetResourceSmallImageHtml(IResourceInfo resource) {
		    return GetResourceSmallImageHtml(GetName(resource));
		}

		public static string GetResourceSmallImageHtml(string name) {
			return string.Format("<img src='{2}' class='resourceSmall resource{0}' title='{1}' alt='{1}' resourceName='{0}'/>", name, LanguageManager.Localize(name), GetEtcImage("Fill"));
		}

		#endregion Images

		#region Script

		public static string GetScript( string name ) {
			string scriptName = string.Format("{0}.js", name);
			return Combine(ScriptsPath, scriptName);
		}

		#endregion Script

		#region Styles

		public static string GetStyle(string name) {
			string scriptName = string.Format("{0}.css", name);
			return Combine(StylesCommonPath, scriptName);
		}

		public static string GetLocalizedStyle(string name) {
			string scriptName = string.Format("{0}.css", name);
			return Combine(StylesLocalizedPath, scriptName);
		}

		#endregion Styles

		#region Constructor

		static ResourcesManager() {
			imagesPath = ConfigurationManager.AppSettings["imagesPath"];
			scriptPath = ConfigurationManager.AppSettings["scriptPath"];
			stylePath = ConfigurationManager.AppSettings["stylePath"];

            if( string.IsNullOrEmpty(imagesPath) ) {
                imagesPath = "http://resources.orionsbelt.eu/Images" ;
            }

            if( string.IsNullOrEmpty(scriptPath) ) {
                scriptPath = "http://resources.orionsbelt.eu/Scripts" ;
            }

            if( string.IsNullOrEmpty(stylePath) ) {
                stylePath = "http://resources.orionsbelt.eu/Styles" ;
            }
		}

		#endregion Constructor

	}
}

