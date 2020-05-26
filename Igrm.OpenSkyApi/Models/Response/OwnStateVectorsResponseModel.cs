using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Response
{
    public class OwnStateVectorsResponseModel
    {
        /// <summary>
        /// The time which the state vectors in this response are associated with. All vectors represent the state of a vehicle with the interval [time−1,time].
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("states")]
        public dynamic[][]? RawStates { get; set; }

        /// <summary>
        /// The state vectors.
        /// </summary>
        public List<StateVector> StateVectors
        {
            get
            {
                var result = RawStates?.Select(x => (StateVector)x)?.ToList();
                return result ?? new List<StateVector>();
            }
        }
    }
}
