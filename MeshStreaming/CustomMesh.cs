using System.Collections.Generic;
using ZeroFormatter;
using Newtonsoft.Json;

namespace MeshStreaming
{
    [ZeroFormattable]
	[JsonObject(MemberSerialization.OptIn)]

    public class CustomMesh
    {
        [Index(0)]
		[JsonProperty]
        public virtual IList<float[]> vertices { get; set; }

        [Index(1)]
		[JsonProperty]
        public virtual IList<float[]> uvs { get; set; }

        [Index(2)]
		[JsonProperty]
        public virtual IList<float[]> normals { get; set; }

        [Index(3)]
		[JsonProperty]
        public virtual IList<int[]> faces { get; set; }

        public CustomMesh() { }
    }


}
