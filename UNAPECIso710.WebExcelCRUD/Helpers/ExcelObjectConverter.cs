using LinqToExcel;
using LinqToExcel.Query;
using System;
using System.Collections.Generic;

namespace UNAPECIso710.WebExcelCRUD.Helpers
{
    public static class ExcelObjectConverter
    {

        public static Entity To<Entity>(this Row row) where Entity : new()
        {
            try
            {
                var result = new Entity();
                foreach (var p in typeof(Entity).GetProperties())
                {
                    var valueInData = row[p.Name].Value;

                    var destiny = result.GetType();
                    destiny.GetProperty(p.Name).SetValue(destiny, valueInData);
                }
                return result;
            }
            catch { }

            return default(Entity);
        }

        public static IEnumerable<Entity> AsList<Entity>(this ExcelQueryable<Row> query) where Entity : new()
        {
            try
            {
                var result = new List<Entity>();
                foreach (var item in query)
                {
                    var newItem = new Entity();

                    foreach (var p in typeof(Entity).GetProperties())
                    {
                        var valueInData = item[p.Name].Value;
                       
                        var destiny = newItem.GetType();
                        destiny.GetProperty(p.Name).SetValue(newItem, valueInData);
                    }

                    result.Add(newItem);
                }
                return result;
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }

            return default(List<Entity>);
        }


    }
}