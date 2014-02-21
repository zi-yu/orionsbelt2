using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class InvoicePlayerNameEditor : InvoiceNameEditor
    {

        protected override void Render(HtmlTextWriter writer, Invoice t, int renderCount, bool flipFlop)
        {

            if (string.IsNullOrEmpty(t.Name))
            {
                base.Render(writer, t, renderCount, flipFlop);
            }
            else
            {
                writer.Write(t.Name);
            }
        }

        public override void Update(Invoice entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                entity.Name = text.Text;
            }
        }

    }
}
