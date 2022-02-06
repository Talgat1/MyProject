using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.db
{
    public interface ISqlite
    {
        string GetDatabasePath(string filename);
    }
}
