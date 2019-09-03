using System;
using System.Collections.Generic;
using System.Text;

namespace Igrm.OpenSkyApi.Models.Response
{
    public class OwnStateVectorsResponseModel
    {
        /// <summary>
        /// The time which the state vectors in this response are associated with. All vectors represent the state of a vehicle with the interval [time−1,time].
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// The state vectors.
        /// </summary>
        public List<StateVector> StateVectors { get; set; }
    }
}
