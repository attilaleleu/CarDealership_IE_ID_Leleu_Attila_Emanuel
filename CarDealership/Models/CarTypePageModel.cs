using Microsoft.AspNetCore.Mvc.RazorPages;
using CarDealership.Data;
using System.Runtime.InteropServices;

namespace CarDealership.Models

{
    public class CarTypePageModel:PageModel
    {
        public List<AssignedTypeData> AssignedTypeDataList;

        public void PopulateAssignedTypeData(CarDealershipContext context, Car car)
        {
            var allTypes = context.Type;
            var carTypes = new HashSet<int>(
                car.CarTypes.Select(c => c.TypeID));
                AssignedTypeDataList = new List<AssignedTypeData>();

            foreach (var tp in allTypes)
            {
                AssignedTypeDataList.Add(new AssignedTypeData
                {
                    TypeID = tp.ID,
                    Make = tp.TypeDescription,
                    Assigned = carTypes.Contains(tp.ID)

                });
            }
        }

        public void UpdateCarTypes(CarDealershipContext context, string[] selectedTypes, Car carToUpdate)
        {
            if (selectedTypes.Length == null)
            {
                carToUpdate.CarTypes = new List<CarType>();
                return;
            }
            var selectedTypesHS = new HashSet<string>(selectedTypes);
            var carTypes = new HashSet<int>
                (carToUpdate.CarTypes.Select(c => c.Type.ID));
            foreach(var tp in context.Type)
            {
                if (selectedTypesHS.Contains(tp.ID.ToString()))
                {
                    if (!carTypes.Contains(tp.ID))
                    {
                        carToUpdate.CarTypes.Add(
                            new CarType
                            {
                                CarID = carToUpdate.ID,
                                TypeID = tp.ID
                            });
                    }
                }
                else
                {
                    if (carTypes.Contains(tp.ID))
                    {
                        CarType courseToRemove = carToUpdate.CarTypes.SingleOrDefault(i => i.TypeID == tp.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
