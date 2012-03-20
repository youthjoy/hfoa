using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.Model;
using QX.BLL;

namespace QX.GPS
{
    public class CarHelper
    {
        private BLL.Bll_GPSRecord GpsInstance = new QX.BLL.Bll_GPSRecord();

        /// <summary>
        /// 获取GPS记录数据
        /// </summary>
        /// <param name="carNo"></param>
        /// <returns></returns>
        public GPSRecord GetModel(string carNo)
        {
            return GpsInstance.GetModel(" and License_Plate='" + carNo + "'");
        }      
 
        public GPSRecord GetMaxModel(string carNo)
        {
            return GpsInstance.GetMax(carNo);
        }

    }
}
