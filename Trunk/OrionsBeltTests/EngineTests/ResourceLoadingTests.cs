using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class ResourceLoadingTests : BaseTests {

        #region Tests

        [Test]
        public void TestEmptyLoading()
        {
            ResourceList list = new ResourceList();
            Assert.IsTrue(list.Count == 0, "Should be zero");
        }

        [Test]
        public void TestIntrinsicLoading()
        {
            ConvertList(RulesUtils.GetIntrinsicResources());
        }

        [Test]
        public void TestUnitLoading()
        {
            ConvertList(RulesUtils.GetUnitResources());
        }

        [Test]
        public void TestFacilityLoading()
        {
            ConvertList(RulesUtils.GetFacilityResources());
        }

        private void ConvertList(System.Collections.IEnumerable coll )
        {
            List<IResourceInfo> infos = new List<IResourceInfo>();
            foreach (IResourceInfo info in coll)
            {
                infos.Add(info);
            }
            StoreLoad(infos);
        }

        private void StoreLoad(IList<IResourceInfo> list)
        {
            ResourceList original = new ResourceList();

            foreach (IResourceInfo info in list) {
                IPlanetResource random = EngineUtils.GetRandomPlanetResource(info);
                original.DirectAdd(random);
            }

            string data = ResourceUtils.SerializeResourceList(original);
            ResourceList loaded = ResourceUtils.DeserializeResourceList(data);

            Assert.AreEqual(original.Count, loaded.Count, "Count mismatch for: '{0}'", data);

            foreach (IResourceInfo info in list) {
                IList<IPlanetResource> originalResource = original.Get(info);
                IList<IPlanetResource> loadedResource = loaded.Get(info);
                CompareResources(info, originalResource, loadedResource);
            }
        }

        private void CompareResources(IResourceInfo info, IList<IPlanetResource> original, IList<IPlanetResource> loaded)
        {
            Assert.IsFalse(loaded.Count == 0, "Loaded has no `{0}' resources", info.Name);
            Assert.AreEqual(original.Count, loaded.Count, "Count mismatch for `{0}'", info.Name);

            foreach (IPlanetResource originalResource in original) {
                bool found = false;
                foreach (IPlanetResource loadedResource in loaded) {
                    found = AreEqual(originalResource, loadedResource);
                    if (found) {
                        break;
                    }
                }
                Assert.IsTrue(found, "Resource `{0}' not found", info.Name);
            }

            

        }

        private bool AreEqual(IPlanetResource originalResource, IPlanetResource loadedResource)
        {
            if (originalResource.Info != loadedResource.Info) {
                return false;
            }
            if (originalResource.Level != loadedResource.Level) {
                return false;
            }
            if (originalResource.Quantity != loadedResource.Quantity) {
                return false;
            }
            if (originalResource.State != loadedResource.State) {
                return false;
            }

            return true;
        }

        #endregion Tests

    };
}