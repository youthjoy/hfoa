using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    [Serializable]
    public partial class Bll_HR_Operate
    {
        private ADOHR_In instance = new ADOHR_In();

        private ADOHR_AA aInstance = new ADOHR_AA();

        private ADOHR_TimeSheet atInstance = new ADOHR_TimeSheet();

        private ADOHR_Benefit abInstance = new ADOHR_Benefit();


        private ADOHR_Evaluation aeInstance = new ADOHR_Evaluation();


        //职位变动添加删除
        public bool AddUpdatePlanObject(HR_In info)
        {
            int result = 0;
            if (info != null)
            {
                if (info.HM_ID.Equals(0))
                {
                    result = instance.Add(info);
                }
                else
                {
                    result = instance.Update(info);
                }
            }
            return result > 0 ? true : false;
        }

        //奖惩管理
        public bool AddUpdatePlanObject(HR_AA info)
        {
            int result = 0;
            if (info != null)
            {
                if (info.AA_ID.Equals(0))
                {
                    result = aInstance.Add(info);
                }
                else
                {
                    result = aInstance.Update(info);
                }
            }
            return result > 0 ? true : false;
        }

        //考勤
        public bool AddUpdatePlanObject(HR_TimeSheet info)
        {
            int result = 0;
            if (info != null)
            {
                if (info.TS_ID.Equals(0))
                {
                    result = atInstance.Add(info);
                }
                else
                {
                    result = atInstance.Update(info);
                }
            }
            return result > 0 ? true : false;
        }

        //考评

        public bool AddUpdatePlanObject(HR_Evaluation info)
        {
            int result = 0;
            if (info != null)
            {
                if (info.Eva_ID.Equals(0))
                {
                    result = aeInstance.Add(info);
                }
                else
                {
                    result = aeInstance.Update(info);
                }
            }
            return result > 0 ? true : false;
        }

        //福利

        public bool AddUpdatePlanObject(HR_Benefit info)
        {
            int result = 0;
            if (info != null)
            {
                if (info.HRB_ID.Equals(0))
                {
                    result = abInstance.Add(info);
                }
                else
                {
                    result = abInstance.Update(info);
                }
            }
            return result > 0 ? true : false;
        }

    }
}
