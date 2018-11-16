using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace APITesting {
public class postCodeBodyBuilder {
    private postCodeBody p_postcodebody = new postCodeBody();
          public postCodeBodyBuilder postcodes (System.Collections.Generic.IList<string> postcodes)
        {
            p_postcodebody.postcodes = postcodes;
            return this;
        }
                                    
              public postCodeBody build()
            {
                return p_postcodebody;
            }
                                           }

}