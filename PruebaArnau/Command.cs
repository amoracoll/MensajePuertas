#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace PruebaArnau
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            try
            {
                List<Element> colectorPuertas = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Doors).WhereElementIsNotElementType().ToList();

                string nombrePuertas = "Las puertas del modelo son las siguientes: ";

                foreach (Element puerta in colectorPuertas)
                {
                    nombrePuertas += "\n" + puerta.Name;
                }

                TaskDialog.Show("Mensaje puertas", nombrePuertas);
                return Result.Succeeded;
            }
            catch(Exception e)
            {
                TaskDialog.Show("Mensaje",e.ToString());
                return Result.Failed;
            }

        }
    }
}
