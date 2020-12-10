using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManhertzMartinBeadando.Entities
{
  public class CelFactory
    {
        public Cel CreateNew()
        {
            return new Cel();
        }
    }
}
