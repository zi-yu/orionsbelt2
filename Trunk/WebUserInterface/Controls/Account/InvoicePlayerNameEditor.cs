using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class InvoiceNIFEditor : InvoiceNifEditor
    {

        protected override void Render(HtmlTextWriter writer, Invoice t, int renderCount, bool flipFlop)
        {

            if (string.IsNullOrEmpty(t.Nif))
            {
                base.Render(writer, t, renderCount, flipFlop);
            }
            else
            {
                writer.Write(t.Nif);
            }
        }

        public override void Update(Invoice entity)
        {
            if (string.IsNullOrEmpty(entity.Nif))
            {
                entity.Nif = text.Text;
            }
        }

    }
}
