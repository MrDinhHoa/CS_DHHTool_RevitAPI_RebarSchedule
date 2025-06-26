using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows;
using DHHTool_RS_Beam_2DCrossSection.MVVM.View;

namespace DHHTool_RS_Beam_2DCrossSection
{
    [Transaction(TransactionMode.Manual)]
    public class RSBeam_2DCrossSection : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            //Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Document document = uidoc.Document;
            try
            {
                using (TransactionGroup transGroup = new TransactionGroup(document))
                {
                    transGroup.Start("Thống kê thép dầm");
                    vMainRS2DCrossSection win = new vMainRS2DCrossSection();
                    bool? dialog = win.ShowDialog();
                    if (dialog != false)
                        return Result.Succeeded;
                    transGroup.Commit();
                }
            }
            catch { }
            return Result.Succeeded;

        }
    }
}
