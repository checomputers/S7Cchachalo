using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace S7Cchachalo
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
