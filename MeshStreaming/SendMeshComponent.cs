using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Quobject.SocketIoClientDotNet.Client;
using Newtonsoft.Json.Linq;

namespace MeshStreaming
{
    public class SendMeshComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the SendMeshComponent class.
        /// </summary>
        public SendMeshComponent()
          : base("SendMesh", "SendMesh",
              "Send mesh through socket",
              "MeshStreaming", "Data")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Bytes", "Bytes", "Bytes to send", GH_ParamAccess.item);
            pManager.AddGenericParameter("Socket", "Socket", "Socket Data", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Send", "Send", "Send data", GH_ParamAccess.item);
			pManager.AddBooleanParameter("JSON", "JSON", "Use JSON Format", GH_ParamAccess.item);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("Status", "Status", "Socket status", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Length", "Length", "Sent data length", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            byte[] bytes = new byte[0];
			var meshObj = new JObject();
            Socket socket = null;
            bool send = false;
			bool useJSON = false;


			if (!DA.GetData(3, ref useJSON)) return;
			if (useJSON)
			{
				if (!DA.GetData(0, ref meshObj)) return;
			}
			else
			{
				if (!DA.GetData(0, ref bytes)) return;
			}

            if (!DA.GetData(1, ref socket)) return;
            if (!DA.GetData(2, ref send)) return;

			if (socket != null)
            {
                if (send)
                {
                    var obj = new JObject();
					if (useJSON)
					{
						obj["mesh"] = meshObj;
					}
					else
					{
						obj["mesh"] = bytes;
					}
                    
                    socket.Emit("gh", obj);

                    DA.SetData(0, "Data Sent");
                    DA.SetData(1, bytes.Length);
                }else
                {
                    DA.SetData(0, "Data Not Sent");
                }
            }else
            {
                DA.SetData(0, "Cocket is Null");
            }
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
				//You can add image files to your project resources and access them like this:
				// return Resources.IconForThisComponent;
				//return MeshStreaming.Properties.Resources.Send_Mesh;
				return null;
                
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{690860ff-e5b0-4fcf-aff7-8c74a4be0579}"); }
        }
		// Convert an object to a byte array
		private byte[] ObjectToByteArray(Object obj)
		{
			if (obj == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream();
			bf.Serialize(ms, obj);

			return ms.ToArray();
		}

		// Convert a byte array to an Object
		private JObject ByteArrayToObject(byte[] arrBytes)
		{
			MemoryStream memStream = new MemoryStream();
			BinaryFormatter binForm = new BinaryFormatter();
			memStream.Write(arrBytes, 0, arrBytes.Length);
			memStream.Seek(0, SeekOrigin.Begin);
			JObject obj = (JObject)binForm.Deserialize(memStream);

			return obj;
		}
    }
}