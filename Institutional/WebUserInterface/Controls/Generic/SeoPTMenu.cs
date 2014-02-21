using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Institutional.WebComponents;

namespace Institutional.WebUserInterface.Controls {

    public class SeoPTMenu : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<h1>Torneio Intergal�ctico</h1>");
            writer.Write("<p>Regista-te no <a href='http://www.orionsbelt.eu/torneio-intergalactico-premio-dinheiro/'>torneio intergal�ctico</a> e habilita-te a ganhar 2000� (R$ 5000)!</p>");
            writer.Write("<h1>Artigos Relacionados</h1>");
            writer.Write("<ul>");
            writer.Write("<li><a href='http://www.orionsbelt.eu/pt/jogo-estrategia-online-por-turnos-gratis/'>Jogo de Estrat�gia por Tturnos</a></li>");
            writer.Write("<li><a href='http://www.orionsbelt.eu/pt/jogo-ficcao-cientifica-online-gratis/'>Jogo de Fic��o Cientifica</a></li>");
            writer.Write("<li><a href='http://www.orionsbelt.eu/pt/jogo-estrategia-espacial-online-gratis/'>Jogo de Estrat�gia Espacial</a></li>");
            writer.Write("</ul>");
        }

        #endregion Rendering

    };

}
