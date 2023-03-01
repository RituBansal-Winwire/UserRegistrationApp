using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserRegistrationApp
{
    public interface ISQlliteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
