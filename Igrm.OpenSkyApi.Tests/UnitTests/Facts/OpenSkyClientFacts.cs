﻿using Igrm.OpenSkyApi.Models.Request;
using Igrm.OpenSkyApi.Tests.UnitTests.Fixtures;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Igrm.OpenSkyApi.Tests.UnitTests.Facts
{
    public class OpenSkyClientFacts
    {
        public class GetAllStateVectorsMethod : IClassFixture<HttpClientFixture>
        {
            private readonly HttpClientFixture _httpClientFixture;

            public GetAllStateVectorsMethod(HttpClientFixture httpClientFixture)
            {
                _httpClientFixture = httpClientFixture;
            }

            [Fact]
            void WhenBoudingBoxProvided_ReturnsListOfStates()
            {
                //ARRANGE
                var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Loose);
                handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                                                      "SendAsync",
                                                      ItExpr.IsAny<HttpRequestMessage>(),
                                                      ItExpr.IsAny<CancellationToken>())
                            .ReturnsAsync(new HttpResponseMessage()
                                        {
                                            StatusCode = HttpStatusCode.OK,
                                            Content = new StringContent("{\"time\":1567676180,\"states\":[[\"4b1805\",\"SWR284H \",\"Switzerland\",1567676180,1567676180,8.414,47.5712,1089.66,false,94.65,137.2,-5.2,null,1211.58,\"5521\",false,0],[\"4b1801\",\"SWR     \",\"Switzerland\",1567676105,1567676172,8.5581,47.4534,1135.38,false,0,5,null,null,null,\"1311\",false,0],[\"3c666f\",\"DLH09H  \",\"Germany\",1567676180,1567676180,6.7195,45.8627,10988.04,false,261.12,357.29,0,null,11262.36,\"5362\",false,0],[\"3c5ee6\",\"EWG81B  \",\"Germany\",1567676179,1567676179,9.9781,47.6835,10058.4,false,210.24,148.92,-0.33,null,10309.86,\"0633\",false,0],[\"3c65cc\",\"DLH4KF  \",\"Germany\",1567676180,1567676180,10.0781,46.5468,11879.58,false,226.07,145.01,0,null,12283.44,\"1000\",false,0],[\"4b057f\",\"\",\"Switzerland\",1567676177,1567676179,8.8839,46.1625,null,false,0,0,0,null,248,null,false,3],[\"5110fe\",\"EJU74UZ \",\"Estonia\",1567676180,1567676180,9.0367,46.3327,7208.52,false,211.2,2.93,2.28,null,7490.46,\"1000\",false,0],[\"4b16b9\",\"SWR74U  \",\"Switzerland\",1567676180,1567676180,8.5262,47.4892,434.34,false,69.53,137.1,-3.9,null,502.92,\"3501\",false,0],[\"4b16bb\",\"SWR78A  \",\"Switzerland\",1567676179,1567676179,8.5598,47.46,null,true,9.77,185,null,null,null,\"1000\",false,0],[\"4400e3\",\"EJU84BV \",\"Austria\",1567676180,1567676180,8.2534,47.3615,9357.36,false,225.66,130.01,-5.2,null,9654.54,\"7617\",false,0],[\"471f2e\",\"WZZ479  \",\"Hungary\",1567676179,1567676179,9.3731,47.7209,8526.78,false,187.93,267.65,-2.28,null,8785.86,\"1000\",false,0],[\"4b5da7\",\"\",\"Switzerland\",1567675889,1567675889,8.5573,47.454,null,true,0,255,null,null,null,null,false,0],[\"4690e2\",\"AEE855  \",\"Greece\",1567676132,1567676132,6.0954,46.2266,null,true,3.86,225,null,null,null,null,false,0],[\"4b5da4\",\"\",\"Switzerland\",1567676164,1567676170,8.5568,47.4544,null,true,0.9,67,null,null,null,null,false,0],[\"4b5da3\",\"TE22    \",\"Switzerland\",1567676052,1567676052,8.565,47.4464,null,true,2.83,137,null,null,null,null,false,0],[\"4b5db2\",\"RTT6    \",\"Switzerland\",1567676171,1567676178,8.5528,47.4598,null,true,0.06,137,null,null,null,\"5425\",true,0],[\"440319\",\"LDM1LT  \",\"Austria\",1567676179,1567676179,7.0268,46.8269,11262.36,false,188.83,209.01,0,null,11582.4,\"6667\",false,0],[\"4b0ea6\",\"TESTR9  \",\"Switzerland\",1567676179,1567676180,7.5158,46.4911,8534.4,false,99.08,195.05,0.33,null,8778.24,\"6265\",false,3],[\"3c662b\",\"EWG598  \",\"Germany\",1567676180,1567676180,6.6673,47.6839,10668,false,198.13,181.49,0,null,10660.38,\"4124\",false,0],[\"4401ea\",\"LDM41TR \",\"Austria\",1567676179,1567676179,6.5897,47.2795,10660.38,false,186.91,193.69,0,null,10866.12,\"4133\",false,0],[\"4009dd\",\"TOM12V  \",\"United Kingdom\",1567676179,1567676179,8.8853,47.091,11277.6,false,229.45,127.26,0,null,11559.54,\"5266\",false,0],[\"4b5d9e\",\"TE09    \",\"Switzerland\",1567675890,1567675890,8.5602,47.4535,null,true,1.29,171,null,null,null,null,false,0],[\"738061\",\"ELY347  \",\"Israel\",1567676179,1567676180,8.4786,47.5241,708.66,false,79.35,137.1,-4.23,null,792.48,\"1000\",false,0],[\"4b1618\",\"SWR194Z \",\"Switzerland\",1567676179,1567676179,9.2449,46.7789,8869.68,false,234.07,298.2,-5.2,null,9159.24,\"0246\",false,0],[\"4b1611\",\"SWR32V  \",\"Switzerland\",1567676152,1567676169,8.5611,47.4448,8923.02,true,0,244,null,null,null,\"2207\",false,0],[\"4b1612\",\"SWR57PU \",\"Switzerland\",1567676180,1567676180,7.712,47.0129,4876.8,false,201.42,51.64,0,null,5029.2,\"1000\",false,0],[\"4b1613\",\"SWR195N \",\"Switzerland\",1567675956,1567676052,8.5594,47.4527,4876.8,false,3.6,5,null,null,null,\"6511\",false,0],[\"3453cc\",\"AEA34TH \",\"Spain\",1567676180,1567676180,7.59,47.6493,10668,false,193.51,205.68,0,null,10942.32,\"2504\",false,0],[\"4b161a\",\"SWR563  \",\"Switzerland\",1567676179,1567676179,7.6835,46.9968,6096,false,190.82,51.68,0,null,6263.64,\"1000\",false,0],[\"4b161c\",\"SWR1325 \",\"Switzerland\",1567675908,1567676165,8.562,47.4478,8945.88,false,1.8,64,null,null,null,\"0246\",false,0],[\"4b1620\",\"EDW403  \",\"Switzerland\",1567676178,1567676179,8.5586,47.4495,null,true,9.77,95,null,null,null,\"6047\",false,0],[\"4b0f72\",\"HBFWC   \",\"Switzerland\",1567676180,1567676180,7.6973,47.0431,7490.46,false,143.99,59.04,2.6,null,7719.06,\"1000\",false,0],[\"44002e\",\"FSE1B   \",\"Austria\",1567676178,1567676178,7.4989,46.9145,null,true,0,239,null,null,null,null,false,0],[\"4b169a\",\"        \",\"Switzerland\",1567676175,1567676175,8.56,47.4542,null,true,3.6,185,null,null,null,\"1000\",false,0],[\"4b14cd\",\"P281    \",\"Switzerland\",1567676179,1567676179,7.7312,46.7589,6949.44,false,114.81,154.24,6.5,null,7185.66,\"3654\",false,0],[\"4b5d3b\",\"GALA20  \",\"Switzerland\",1567676177,1567676177,8.5439,47.4605,null,true,9.77,154,null,null,null,\"1174\",false,0],[\"4b5d90\",\"URSULA21\",\"Switzerland\",1567676097,1567676164,8.5605,47.4451,null,false,6.43,154,null,null,null,\"6166\",true,0],[\"40093f\",\"BAW15PZ \",\"United Kingdom\",1567676180,1567676180,8.3667,45.8433,11056.62,false,247.41,96.33,-5.2,null,11384.28,\"2167\",false,0],[\"4247e7\",\"VPCHJ   \",\"United Kingdom\",1567676172,1567676178,7.5406,47.5927,null,true,0.19,165,null,null,null,null,false,0],[\"7380c8\",\"ELY323  \",\"Israel\",1567676179,1567676179,7.5697,47.2397,11574.78,false,229.09,284.57,0.33,null,11910.06,\"1000\",false,0],[\"4247b9\",\"VPCPF   \",\"United Kingdom\",1567676180,1567676180,9.6947,47.1349,13716,false,234.53,159.86,0.33,null,14089.38,\"0127\",false,0],[\"4b5c41\",\"DIANA1  \",\"Switzerland\",1567676071,1567676071,8.5637,47.4459,null,true,3.09,154,null,null,null,\"4474\",false,0],[\"4b5c44\",\"\",\"Switzerland\",1567675917,1567675917,8.5615,47.441,null,true,8.75,154,null,null,null,null,false,0],[\"4b5c37\",\"URSULA6 \",\"Switzerland\",1567675838,1567675903,8.564,47.4452,null,true,6.43,171,null,null,null,null,false,0],[\"4b5c1e\",\"ZEBRA2  \",\"Switzerland\",1567676061,1567676061,8.5646,47.4585,null,true,8.75,275,null,null,null,null,false,0],[\"4b5c65\",\"ORION1  \",\"Switzerland\",1567676175,1567676177,8.5297,47.4795,null,true,13.89,329,null,null,null,null,false,0],[\"345618\",\"TOM5469 \",\"Spain\",1567676179,1567676179,7.9404,47.33,10972.8,false,221.73,288.39,0,null,11300.46,\"2750\",false,0],[\"4b5c56\",\"GALA40  \",\"Switzerland\",1567676069,1567676069,8.5266,47.4812,null,true,10.8,208,null,null,null,null,false,0],[\"4b5c5d\",\"FLORI261\",\"Switzerland\",1567675897,1567675897,8.5531,47.4461,null,true,1.03,8,null,null,null,\"7205\",true,0],[\"4bab2c\",\"THY3DX  \",\"Turkey\",1567676179,1567676180,7.495,47.7085,1722.12,false,113.43,98.61,12.03,null,1844.04,\"6717\",false,0],[\"44cdc9\",\"BEL3882 \",\"Belgium\",1567676180,1567676180,6.2793,46.9727,10980.42,false,271.88,2.49,-0.33,null,11201.4,\"4031\",false,0],[\"3c0ca2\",\"TUI693  \",\"Germany\",1567676179,1567676180,6.6673,46.4507,9753.6,false,257.86,344.49,-0.33,null,10027.92,\"5542\",false,0],[\"4ca8e4\",\"RYR56RF \",\"Ireland\",1567676179,1567676179,6.3247,46.5003,11277.6,false,194.02,193.96,-0.33,null,11574.78,\"1132\",false,0],[\"a3f7c9\",\"N355EE  \",\"United States\",1567676179,1567676179,8.2764,46.7092,13091.16,false,184.23,155.94,3.58,null,13449.3,\"6706\",false,0],[\"3e174b\",\"AZE69QQ \",\"Germany\",1567676161,1567676175,6.0987,46.2352,365.76,true,0,129,null,null,null,\"2364\",false,0],[\"4baa8e\",\"THY8VG  \",\"Turkey\",1567676081,1567676081,6.0954,46.2265,null,true,5.14,225,null,null,null,\"5716\",false,0],[\"4b7fba\",\"\",\"Switzerland\",1567675897,1567675900,8.8733,46.1642,null,false,0,0,0,null,252,null,false,3],[\"4b7fae\",\"GIZ31   \",\"Switzerland\",1567676179,1567676179,8.3157,47.1015,510.54,false,80.03,39.52,16.58,null,502.92,\"6121\",false,0],[\"4b7fac\",\"COL61   \",\"Switzerland\",1567676180,1567676180,8.5191,47.1748,944.88,false,163.46,283.47,-0.65,null,929.64,\"6112\",false,0],[\"896463\",\"ETD11K  \",\"United Arab Emirates\",1567676180,1567676180,8.6608,47.7203,11887.2,false,262.19,105.13,-0.33,null,12192,\"7563\",false,0],[\"aae6d5\",\"DAL173  \",\"United States\",1567676179,1567676179,6.2025,46.6318,8915.4,false,240.05,299.53,6.18,null,9159.24,\"5773\",false,0],[\"8964bc\",\"ETD44T  \",\"United Arab Emirates\",1567676178,1567676178,8.5526,47.4598,null,true,0,95,null,null,null,\"3052\",false,0],[\"3c49e8\",\"CFG1DA  \",\"Germany\",1567676180,1567676180,8.0438,47.2402,10972.8,false,270.33,46.16,0,null,11239.5,\"5341\",false,0],[\"4ca739\",\"RYR52KZ \",\"Ireland\",1567676179,1567676179,7.7908,47.5297,11277.6,false,186.91,221.76,0,null,11590.02,\"1135\",false,0],[\"4ca76f\",\"EIN3GC  \",\"Ireland\",1567676179,1567676179,7.8924,47.3308,4792.98,false,183.04,280.36,13.98,null,4914.9,\"3003\",false,0],[\"4b7f44\",\"SUI564  \",\"Switzerland\",1567676179,1567676179,9.144,47.3852,6507.48,false,213.56,54.51,11.38,null,6736.08,\"7530\",false,0],[\"4b7f5b\",\"PEG21   \",\"Switzerland\",1567676179,1567676179,8.288,47.1101,861.06,false,85.47,214.46,0,null,975.36,\"2407\",false,0],[\"4ca726\",\"RYR52AN \",\"Ireland\",1567676179,1567676179,6.5101,45.9707,10668,false,215.15,137.23,-0.33,null,10972.8,\"7572\",false,0],[\"4ca624\",\"RYR5N   \",\"Ireland\",1567676180,1567676180,6.3819,47.3499,11582.4,false,262.37,0.34,0.33,null,11833.86,\"5741\",false,0],[\"345205\",\"VLG189L \",\"Spain\",1567676178,1567676179,6.4262,47.2715,10980.42,false,269.06,359.56,0,null,11193.78,\"5536\",false,0],[\"448441\",\"BAW154  \",\"Belgium\",1567676179,1567676179,7.3913,47.4469,11582.4,false,225.64,288.48,0.33,null,11826.24,\"7512\",false,0],[\"4d00d4\",\"LGL31C  \",\"Luxembourg\",1567676180,1567676180,6.7362,46.2018,7620,false,155.79,170.88,0,null,7879.08,\"5654\",false,0],[\"3c0a59\",\"DLH8LX  \",\"Germany\",1567676179,1567676179,9.1971,47.3501,11506.2,false,251.22,348.78,-4.88,null,11795.76,\"1000\",false,0],[\"424440\",\"AFL2648 \",\"United Kingdom\",1567676179,1567676179,10.3448,45.8712,10668,false,217.06,229.33,0,null,11064.24,\"7222\",false,0],[\"40631d\",\"EZY34KL \",\"United Kingdom\",1567676180,1567676180,8.6615,47.0604,11582.4,false,218.63,301.33,-0.33,null,11887.2,\"2771\",false,0],[\"3950c8\",\"AFR13XP \",\"France\",1567676180,1567676180,8.4464,46.4077,11879.58,false,224.73,148.38,0.33,null,12199.62,\"7671\",false,0],[\"3c4906\",\"EWG2834 \",\"Germany\",1567676180,1567676180,8.0352,47.8202,8816.34,false,192.4,208.07,4.23,null,8999.22,\"0626\",false,0],[\"4409a3\",\"\",\"Austria\",1567676180,1567676180,10.031,46.1866,null,false,15.13,179.14,-3,null,1445,null,false,3],[\"406f0b\",\"TCX3EQ  \",\"United Kingdom\",1567676180,1567676180,6.604,47.6229,10965.18,false,211.32,288.3,0.98,null,11224.26,\"2740\",false,0],[\"396449\",\"AFR226  \",\"France\",1567676179,1567676179,8.9801,47.6244,10668,false,253.91,104.43,0,null,10942.32,\"0665\",false,0],[\"400d91\",\"EZY73WN \",\"United Kingdom\",1567676179,1567676180,10.31,47.7128,11582.4,false,224.46,315.65,-0.33,null,11887.2,\"3126\",false,0],[\"4074e4\",\"BAW36   \",\"United Kingdom\",1567676180,1567676180,6.9756,47.5458,12184.38,false,232.32,287.79,-0.33,null,12481.56,\"7527\",false,0],[\"502d0c\",\"DLH55P  \",\"Latvia\",1567676179,1567676180,6.0759,46.4083,5501.64,false,158.37,232.13,-6.18,null,5676.9,\"1000\",false,0],[\"4b1a1e\",\"EZS26DG \",\"Switzerland\",1567676179,1567676179,6.8628,47.4806,4000.5,false,170.66,108.82,-6.5,null,4175.76,\"0735\",false,0],[\"4b1a1b\",\"EZS58NT \",\"Switzerland\",1567676179,1567676180,6.3782,46.0421,4175.76,false,193.84,285.55,-11.05,null,4320.54,\"1000\",false,0],[\"400dad\",\"EZY8184 \",\"United Kingdom\",1567676179,1567676179,6.6209,46.4832,11559.54,false,221.99,313.31,3.9,null,11811,\"5736\",false,0],[\"4b1a3b\",\"\",\"Switzerland\",1567676176,1567676176,6.0926,46.2269,null,true,23.66,45,null,null,null,null,false,0],[\"4ba933\",\"THY2QY  \",\"Turkey\",1567676179,1567676180,10.3432,47.7216,12184.38,false,207.73,261.17,0,null,12504.42,\"3212\",false,0],[\"4ca373\",\"RYR1KE  \",\"Ireland\",1567676179,1567676179,10.0365,46.8421,11277.6,false,233.4,112.55,0,null,11650.98,\"7575\",false,0],[\"4408ec\",\"EWG9ZX  \",\"Austria\",1567676180,1567676180,7.3001,47.1831,11269.98,false,188.83,209.01,0,null,11536.68,\"0636\",false,0],[\"44a828\",\"JAF4DX  \",\"Belgium\",1567676179,1567676179,8.1352,47.147,11574.78,false,211.99,284.47,-0.33,null,11902.44,\"7524\",false,0],[\"4408d7\",\"EWG6837 \",\"Austria\",1567676179,1567676179,6.2662,46.3419,10660.38,false,192.16,226.74,0.33,null,10919.46,\"3066\",false,0],[\"4ba904\",\"THY6KT  \",\"Turkey\",1567676179,1567676179,9.6358,47.5733,3703.32,false,166.2,91.24,12.68,null,3787.14,\"2741\",false,0],[\"abe2e1\",\"N865R   \",\"United States\",1567676173,1567676173,6.1232,46.2455,null,true,5.66,45,null,null,null,\"1000\",false,0],[\"3cefc0\",\"LXG55CE \",\"Germany\",1567676180,1567676180,10.0202,47.4491,11887.2,false,249.42,64.33,0.33,null,12245.34,\"5764\",false,0],[\"4b43b0\",\"REGAQM  \",\"Switzerland\",1567676179,1567676180,7.5512,46.7105,1211.58,false,22.6,78.18,-1.95,null,1341.12,\"7000\",false,3],[\"49d092\",\"EWG89K  \",\"Czech Republic\",1567676180,1567676180,6.9362,46.5877,11582.4,false,271.8,51.07,-0.33,null,11849.1,\"2332\",false,0],[\"4b43aa\",\"REGA2   \",\"Switzerland\",1567675893,1567675997,7.3327,47.5279,609.6,false,62.11,238.55,0.65,null,731.52,\"7100\",false,0],[\"4405aa\",\"LDX7C   \",\"Austria\",1567676179,1567676179,8.6037,46.5405,null,true,204.66,174.52,0,null,null,\"7657\",false,0],[\"4d21ea\",\"RYR4XZ  \",\"Malta\",1567676179,1567676179,6.7282,47.5877,8999.22,false,243.93,19.85,-8.45,null,9212.58,\"2327\",false,0],[\"49d152\",\"OKPMP   \",\"Czech Republic\",1567676179,1567676180,9.1932,47.6103,7315.2,false,112.75,250.82,0,null,7559.04,\"6662\",false,0],[\"4b19f1\",\"SWR36N  \",\"Switzerland\",1567676019,1567676085,8.5597,47.4557,6583.68,true,0,5,null,null,null,\"0565\",false,0],[\"4b19f2\",\"SWR45C  \",\"Switzerland\",1567676179,1567676179,7.5207,47.3915,5562.6,false,191.34,289.31,7.15,null,5737.86,\"3047\",false,0],[\"4b19fa\",\"SWR116W \",\"Switzerland\",1567676177,1567676179,8.5571,47.4651,365.76,true,14.4,168,null,null,null,\"0131\",false,0],[\"4b19fb\",\"SWR35Q  \",\"Switzerland\",1567676179,1567676179,7.4724,47.6391,5661.66,false,203.53,109.03,-11.38,null,5844.54,\"2022\",false,0],[\"407025\",\"CFE88K  \",\"United Kingdom\",1567676180,1567676180,7.1094,46.0286,10043.16,false,226.41,324.43,5.2,null,10347.96,\"5704\",false,0],[\"51009a\",\"BRU881  \",\"Belarus\",1567676180,1567676180,9.9828,46.002,7315.2,false,193.03,243.57,-12.03,null,7604.76,\"7217\",false,0],[\"4691c5\",\"AEE5ZH  \",\"Greece\",1567676179,1567676180,9.7968,46.5978,9075.42,false,243.05,125,7.15,null,9410.7,\"3063\",false,0],[\"4b4262\",\"\",\"Switzerland\",1567675780,1567676176,7.4544,46.8822,426.72,false,36.87,49.3,0,null,1143,\"0671\",false,3],[\"39840b\",\"TAP944  \",\"France\",1567676179,1567676179,6.0512,46.1988,617.22,false,66.94,45.62,-3.25,null,685.8,\"1000\",false,0],[\"4b0652\",\"\",\"Switzerland\",1567675887,1567676146,8.4779,47.4118,396.24,true,58.58,48.35,-1,null,null,\"7000\",false,3],[\"440582\",\"EJU98YZ \",\"Austria\",1567676180,1567676180,8.4408,47.672,10058.4,false,202.32,177.81,0,null,10279.38,\"0765\",false,0],[\"3c66ab\",\"DLH7C   \",\"Germany\",1567676179,1567676179,8.548,47.4582,434.34,false,78.12,276.05,11.38,null,464.82,\"1000\",false,0],[\"4b9063\",\"PGT7WD  \",\"Turkey\",1567676179,1567676179,10.1124,47.3563,8519.16,false,242.7,96.21,6.83,null,8755.38,\"3042\",false,0],[\"4b17e0\",\"SWR81C  \",\"Switzerland\",1567676127,1567676178,8.559,47.448,4244.34,true,0,244,null,null,null,\"1000\",false,0],[\"4b17de\",\"SWR159H \",\"Switzerland\",1567676179,1567676179,6.2393,46.689,5356.86,false,187.77,347.98,15.61,null,5532.12,\"1000\",false,0],[\"4b17df\",\"SWR119G \",\"Switzerland\",1567676173,1567676173,8.5586,47.4483,null,true,0.06,244,null,null,null,\"2000\",false,0],[\"4b17e2\",\"SWR287A \",\"Switzerland\",1567676179,1567676179,8.1673,47.2134,4244.34,false,194.62,45.54,-4.88,null,4411.98,\"1000\",false,0],[\"4b17e3\",\"SWR87R  \",\"Switzerland\",1567676175,1567676177,8.5569,47.456,null,true,0,5,null,null,null,\"2000\",false,0],[\"4b17e6\",\"SWR137L \",\"Switzerland\",1567676179,1567676179,9.3651,47.7578,9144,false,208.39,247.04,-0.33,null,9433.56,\"1000\",false,0],[\"4b17fc\",\"SWR2175 \",\"Switzerland\",1567676179,1567676179,7.3052,46.7909,6697.98,false,209.37,51.38,-0.33,null,6911.34,\"5373\",false,0],[\"4b17fa\",\"SWR33U  \",\"Switzerland\",1567676107,1567676114,6.0968,46.2298,358.14,false,69.12,45.6,-1.3,null,480.06,\"2071\",false,0],[\"4b1901\",\"EDW33   \",\"Switzerland\",1567676180,1567676180,8.3247,47.6262,1554.48,false,107.24,109.91,-6.83,null,1638.3,\"2032\",false,0]]}"),
                                        });
                _httpClientFixture.SetupHttpClient(handlerMock.Object);

                //ACT
                IOpenSkyClient client = new OpenSkyClient(_httpClientFixture.HttpClient);
                var response = client.GetAllStateVectors(new AllStateVectorsRequestModel() { BoundingBox = new BoundingBox() { Lamin = 45.8389m, Lomin = 5.9962m, Lamax = 47.8229m, Lomax = 10.5226m } });

                //ASSERT
                Assert.True(response.StateVectors.Count>0);
            }
        }
    }
}