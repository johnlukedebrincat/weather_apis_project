﻿using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.Text;
using WeatherWebClient.Models;

namespace WeatherWebClient.JSONParser
{
    class JsonParser<T>:IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if(disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }

        public T parse(string json)
        {
            var deserializerModel = Activator.CreateInstance(typeof(T));
       
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));

                deserializerModel = serializer.ReadObject(memoryStream);
            }

            return (T) deserializerModel;
     
        }
    }
}
