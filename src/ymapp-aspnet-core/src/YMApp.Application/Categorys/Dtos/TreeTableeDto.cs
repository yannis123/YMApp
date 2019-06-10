using System;
using System.Collections.Generic;
using System.Text;

namespace YMApp.Categorys.Dtos
{
    public class TreeTableeDto
    {
        public List<CategoryListDto> Data { get; set; }
        public int Code { get; set; }
        public string Msg { get; set; }
        public int Count { get; set; }
    }
}
