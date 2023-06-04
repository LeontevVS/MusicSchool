using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchool
{
    class Context
    {
        private static dbMusicSchoolEntities _context;

        public static dbMusicSchoolEntities GetContext()
        {
            if (_context == null)
            {
                _context = new dbMusicSchoolEntities();
            }

            return _context;
        }
    }
}
