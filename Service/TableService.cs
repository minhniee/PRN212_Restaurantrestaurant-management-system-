using Repository;
using Repository.Entities;

namespace Service;

public class TableService
{
    TableContainer container = new TableContainer();

    public List<Table> GetTables()
    {
        return container.GetTables();
    }

    public List<Table> GetTablesByName(string stringSearch)
    {
        var data = container.GetTables().Where(x => x.TableName.Contains(stringSearch));
        return data.ToList();
    }

    public void RemoveTable(Table category)
    {
        container.DeleteTable(category);
    }

    public void AddTable(Table category)
    {
        container.AddTable(category);
    }

    public void UpdateTable(Table category)
    {
        container.UpdateTable(category);
    }
}