using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Forms;
using Autodesk.Revit.UI.Selection;




namespace ClassLibrary1
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class ClassLibrary1 : IExternalCommand
    {
        //public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        //{
        //MessageBox.Show("Xin chao");
        //return Result.Succeeded;

        //}
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            ICollection<ElementId> selectElements = uidoc.Selection.GetElementIds();
            int totalCount = selectElements.Count;
            MessageBox.Show(" Ban da chon " + totalCount.ToString() + " elements");
            return Result.Succeeded;
        }
    }
}

namespace A004_SeclectPoint
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            XYZ point1 = uidoc.Selection.PickPoint();
            XYZ point2 = uidoc.Selection.PickPoint();
            XYZ point3 = uidoc.Selection.PickPoint();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(point1.ToString());
            sb.AppendLine(point2.ToString());
            sb.AppendLine(point3.ToString());

            MessageBox.Show("Bạn đã lựa chọn các điểm points:\n" + sb.ToString());
            return Result.Succeeded;
        }
    }

}

namespace A003_SelectEdge
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit
    .Attributes.TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData
        commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            IList<Reference> referenceCollection = uidoc.Selection.PickObjects(ObjectType.Edge);

            MessageBox.Show("You have selected total" + referenceCollection.Count.ToString() + "Edges.");
            return Result.Succeeded;
        }
    }
}

namespace A005_TaoListElements
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit
    .Attributes.TransactionMode.Manual)]

    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData
        commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            TaskDialog.Show("Revit", "Số lượng đối tượng được chọn: " + selectedIds.Count.ToString());
            ICollection<ElementId> selectedWallIds = new List<ElementId>();
            foreach (ElementId id in selectedIds)
            {
                Element elements1 = uidoc.Document.GetElement(id);
                if (elements1 is Wall)
                {
                    selectedWallIds.Add(id);
                }    

            }
            // Set the created element set as current select element set.
            uidoc.Selection.SetElementIds(selectedWallIds);
            if (0 != selectedWallIds.Count)
            {
                TaskDialog.Show("Revit", selectedWallIds.Count.ToString() + "Đối tượng Tường đã được chọn");
            }
            else 
            {
                TaskDialog.Show("Revit", "Không có đối tượng Tường nào được chọn!");
            }
            return Result.Succeeded;
        }
    }
}

