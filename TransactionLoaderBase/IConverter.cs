using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLoaderBase
{
    public interface IConverter
    {
        List<Transaction> Convert();
    }
}
