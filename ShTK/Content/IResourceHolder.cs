using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShTK.Content
{
    public interface IResourceHolder
    {
        void Load();

        void LoadComplete();
    }
}
