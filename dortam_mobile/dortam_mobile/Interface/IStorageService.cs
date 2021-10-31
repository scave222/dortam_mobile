using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dortam_mobile.Interface
{
    public interface IStorageService
    {
        Task<T> Read<T>(string name);
        Task Write<T>(string name, T value);
    }
}
