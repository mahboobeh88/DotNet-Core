using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public enum PageType
    {
        HomePage = 1,
        aboutUs = 2,
        ContactUs = 3,
        Products = 4
    }
    public enum SectionType
    {
        Header = 1 ,
        Bodey=2,
        Footer=3,
        SideBar_Header=4,
        SideBar_Body=5,
        SideBar_Footer=6
    }
    public enum MediaType
    {
        Image =1 ,
        Video =2,
        Audio =3
    }
}
