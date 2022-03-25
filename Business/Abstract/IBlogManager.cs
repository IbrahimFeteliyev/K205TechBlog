using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogManager
    {
        List<Blog> GetAll();
        void Create(Blog blog);

    }
}
