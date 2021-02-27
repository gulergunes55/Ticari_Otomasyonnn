using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticarii_Otomasyonn
{
    class sqlbaglantisi

    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-AOTI51G;Initial Catalog=DboTicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
    //Data Source=DESKTOP-AOTI51G;Initial Catalog=DboTicariOtomasyon;Integrated Security=True
}
