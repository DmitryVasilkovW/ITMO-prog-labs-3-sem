using System;
using System.Collections.Generic;

namespace LabWork5.Infrastructure.DataAccess.Repositories;

public class MockDatabase
{
    private IList<IMockTable> _tables = new List<IMockTable>();

    public void AddTable(IMockTable table)
    {
        _tables.Add(table);
    }

    public IMockTable? FindByName(string name)
    {
        foreach (IMockTable table in _tables)
        {
            if (table.Name is not null && table.Name.Equals(name, StringComparison.Ordinal))
            {
                return table;
            }
        }

        return null;
    }

    public long? FindBalanceByID(long id)
    {
        foreach (IMockTable table in _tables)
        {
            if (table is MockBillTable)
            {
                if (((MockBillTable)table).Billid == id)
                {
                    return ((MockBillTable)table).Balance;
                }
            }
        }

        return null;
    }
}