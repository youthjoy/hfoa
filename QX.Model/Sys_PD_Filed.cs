using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class Sys_PD_Filed
   {
      private decimal dCP_ID;
      private bool dCP_ID_IsChanged=false;
      [MetaData("DCP_ID","")]
      public decimal DCP_ID
      {
         get{ return dCP_ID; }
         set{ dCP_ID = value; dCP_ID_IsChanged=true; }
      }
      public bool DCP_ID_IsChanged
      {
         get{ return dCP_ID_IsChanged; }
         set{ dCP_ID_IsChanged = value; }
      }
      private string dCP_ModuleName;
      private bool dCP_ModuleName_IsChanged=false;
      [MetaData("DCP_ModuleName","")]
      [StringLength(50, ErrorMessage = "长度不能超过50个字符")]
      public string DCP_ModuleName
      {
         get{ return dCP_ModuleName; }
         set{ dCP_ModuleName = value; dCP_ModuleName_IsChanged=true; }
      }
      public bool DCP_ModuleName_IsChanged
      {
         get{ return dCP_ModuleName_IsChanged; }
         set{ dCP_ModuleName_IsChanged = value; }
      }
      private string dCP_ControlID;
      private bool dCP_ControlID_IsChanged=false;
      [MetaData("DCP_ControlID","")]
      [StringLength(50, ErrorMessage = "长度不能超过50个字符")]
      public string DCP_ControlID
      {
         get{ return dCP_ControlID; }
         set{ dCP_ControlID = value; dCP_ControlID_IsChanged=true; }
      }
      public bool DCP_ControlID_IsChanged
      {
         get{ return dCP_ControlID_IsChanged; }
         set{ dCP_ControlID_IsChanged = value; }
      }
      private string dCP_Label;
      private bool dCP_Label_IsChanged=false;
      [MetaData("DCP_Label","")]
      [StringLength(50, ErrorMessage = "长度不能超过50个字符")]
      public string DCP_Label
      {
         get{ return dCP_Label; }
         set{ dCP_Label = value; dCP_Label_IsChanged=true; }
      }
      public bool DCP_Label_IsChanged
      {
         get{ return dCP_Label_IsChanged; }
         set{ dCP_Label_IsChanged = value; }
      }
      private string dCP_ControlType;
      private bool dCP_ControlType_IsChanged=false;
      [MetaData("DCP_ControlType","")]
      [StringLength(20, ErrorMessage = "长度不能超过20个字符")]
      public string DCP_ControlType
      {
         get{ return dCP_ControlType; }
         set{ dCP_ControlType = value; dCP_ControlType_IsChanged=true; }
      }
      public bool DCP_ControlType_IsChanged
      {
         get{ return dCP_ControlType_IsChanged; }
         set{ dCP_ControlType_IsChanged = value; }
      }
      private string dCP_Type;
      private bool dCP_Type_IsChanged=false;
      [MetaData("DCP_Type","")]
      [StringLength(20, ErrorMessage = "长度不能超过20个字符")]
      public string DCP_Type
      {
         get{ return dCP_Type; }
         set{ dCP_Type = value; dCP_Type_IsChanged=true; }
      }
      public bool DCP_Type_IsChanged
      {
         get{ return dCP_Type_IsChanged; }
         set{ dCP_Type_IsChanged = value; }
      }
      private string dCP_Style;
      private bool dCP_Style_IsChanged=false;
      [MetaData("DCP_Style","")]
      [StringLength(50, ErrorMessage = "长度不能超过50个字符")]
      public string DCP_Style
      {
         get{ return dCP_Style; }
         set{ dCP_Style = value; dCP_Style_IsChanged=true; }
      }
      public bool DCP_Style_IsChanged
      {
         get{ return dCP_Style_IsChanged; }
         set{ dCP_Style_IsChanged = value; }
      }
      private int dCP_Order;
      private bool dCP_Order_IsChanged=false;
      [MetaData("DCP_Order","")]
      public int DCP_Order
      {
         get{ return dCP_Order; }
         set{ dCP_Order = value; dCP_Order_IsChanged=true; }
      }
      public bool DCP_Order_IsChanged
      {
         get{ return dCP_Order_IsChanged; }
         set{ dCP_Order_IsChanged = value; }
      }
      private int dCP_IsHidden;
      private bool dCP_IsHidden_IsChanged=false;
      [MetaData("DCP_IsHidden","")]
      public int DCP_IsHidden
      {
         get{ return dCP_IsHidden; }
         set{ dCP_IsHidden = value; dCP_IsHidden_IsChanged=true; }
      }
      public bool DCP_IsHidden_IsChanged
      {
         get{ return dCP_IsHidden_IsChanged; }
         set{ dCP_IsHidden_IsChanged = value; }
      }
      private int dCP_IsReadonly;
      private bool dCP_IsReadonly_IsChanged=false;
      [MetaData("DCP_IsReadonly","")]
      public int DCP_IsReadonly
      {
         get{ return dCP_IsReadonly; }
         set{ dCP_IsReadonly = value; dCP_IsReadonly_IsChanged=true; }
      }
      public bool DCP_IsReadonly_IsChanged
      {
         get{ return dCP_IsReadonly_IsChanged; }
         set{ dCP_IsReadonly_IsChanged = value; }
      }
      private string dCP_UDef1;
      private bool dCP_UDef1_IsChanged=false;
      [MetaData("DCP_UDef1","")]
      [StringLength(200, ErrorMessage = "长度不能超过200个字符")]
      public string DCP_UDef1
      {
         get{ return dCP_UDef1; }
         set{ dCP_UDef1 = value; dCP_UDef1_IsChanged=true; }
      }
      public bool DCP_UDef1_IsChanged
      {
         get{ return dCP_UDef1_IsChanged; }
         set{ dCP_UDef1_IsChanged = value; }
      }
      private string dCP_UDef2;
      private bool dCP_UDef2_IsChanged=false;
      [MetaData("DCP_UDef2","")]
      [StringLength(200, ErrorMessage = "长度不能超过200个字符")]
      public string DCP_UDef2
      {
         get{ return dCP_UDef2; }
         set{ dCP_UDef2 = value; dCP_UDef2_IsChanged=true; }
      }
      public bool DCP_UDef2_IsChanged
      {
         get{ return dCP_UDef2_IsChanged; }
         set{ dCP_UDef2_IsChanged = value; }
      }
      private string dCP_PageName;
      private bool dCP_PageName_IsChanged=false;
      [MetaData("DCP_PageName","")]
      [StringLength(100, ErrorMessage = "长度不能超过100个字符")]
      public string DCP_PageName
      {
         get{ return dCP_PageName; }
         set{ dCP_PageName = value; dCP_PageName_IsChanged=true; }
      }
      public bool DCP_PageName_IsChanged
      {
         get{ return dCP_PageName_IsChanged; }
         set{ dCP_PageName_IsChanged = value; }
      }
      private DateTime dCP_CreateTime;
      private bool dCP_CreateTime_IsChanged=false;
      [MetaData("DCP_CreateTime","")]
      public DateTime DCP_CreateTime
      {
         get{ return dCP_CreateTime; }
         set{ dCP_CreateTime = value; dCP_CreateTime_IsChanged=true; }
      }
      public bool DCP_CreateTime_IsChanged
      {
         get{ return dCP_CreateTime_IsChanged; }
         set{ dCP_CreateTime_IsChanged = value; }
      }
      private string dCP_Model;
      private bool dCP_Model_IsChanged=false;
      [MetaData("DCP_Model","")]
      [StringLength(50, ErrorMessage = "长度不能超过50个字符")]
      public string DCP_Model
      {
         get{ return dCP_Model; }
         set{ dCP_Model = value; dCP_Model_IsChanged=true; }
      }
      public bool DCP_Model_IsChanged
      {
         get{ return dCP_Model_IsChanged; }
         set{ dCP_Model_IsChanged = value; }
      }
      private int stat;
      private bool stat_IsChanged=false;
      [MetaData("Stat","")]
      public int Stat
      {
         get{ return stat; }
         set{ stat = value; stat_IsChanged=true; }
      }
      public bool Stat_IsChanged
      {
         get{ return stat_IsChanged; }
         set{ stat_IsChanged = value; }
      }
      private string dCP_RefSQL;
      private bool dCP_RefSQL_IsChanged=false;
      [MetaData("DCP_RefSQL","")]
      [StringLength(800, ErrorMessage = "长度不能超过800个字符")]
      public string DCP_RefSQL
      {
         get{ return dCP_RefSQL; }
         set{ dCP_RefSQL = value; dCP_RefSQL_IsChanged=true; }
      }
      public bool DCP_RefSQL_IsChanged
      {
         get{ return dCP_RefSQL_IsChanged; }
         set{ dCP_RefSQL_IsChanged = value; }
      }
      private string dCP_RefValue;
      private bool dCP_RefValue_IsChanged=false;
      [MetaData("DCP_RefValue","")]
      [StringLength(50, ErrorMessage = "长度不能超过50个字符")]
      public string DCP_RefValue
      {
         get{ return dCP_RefValue; }
         set{ dCP_RefValue = value; dCP_RefValue_IsChanged=true; }
      }
      public bool DCP_RefValue_IsChanged
      {
         get{ return dCP_RefValue_IsChanged; }
         set{ dCP_RefValue_IsChanged = value; }
      }
      private string dCP_RefCode;
      private bool dCP_RefCode_IsChanged=false;
      [MetaData("DCP_RefCode","")]
      [StringLength(50, ErrorMessage = "长度不能超过50个字符")]
      public string DCP_RefCode
      {
         get{ return dCP_RefCode; }
         set{ dCP_RefCode = value; dCP_RefCode_IsChanged=true; }
      }
      public bool DCP_RefCode_IsChanged
      {
         get{ return dCP_RefCode_IsChanged; }
         set{ dCP_RefCode_IsChanged = value; }
      }
      private int dCP_TX;
      private bool dCP_TX_IsChanged=false;
      [MetaData("DCP_TX","")]
      public int DCP_TX
      {
         get{ return dCP_TX; }
         set{ dCP_TX = value; dCP_TX_IsChanged=true; }
      }
      public bool DCP_TX_IsChanged
      {
         get{ return dCP_TX_IsChanged; }
         set{ dCP_TX_IsChanged = value; }
      }
      private int dCP_TY;
      private bool dCP_TY_IsChanged=false;
      [MetaData("DCP_TY","")]
      public int DCP_TY
      {
         get{ return dCP_TY; }
         set{ dCP_TY = value; dCP_TY_IsChanged=true; }
      }
      public bool DCP_TY_IsChanged
      {
         get{ return dCP_TY_IsChanged; }
         set{ dCP_TY_IsChanged = value; }
      }
      private int dCP_TI;
      private bool dCP_TI_IsChanged=false;
      [MetaData("DCP_TI","")]
      public int DCP_TI
      {
         get{ return dCP_TI; }
         set{ dCP_TI = value; dCP_TI_IsChanged=true; }
      }
      public bool DCP_TI_IsChanged
      {
         get{ return dCP_TI_IsChanged; }
         set{ dCP_TI_IsChanged = value; }
      }
      private int dCP_Height;
      private bool dCP_Height_IsChanged=false;
      [MetaData("DCP_Height","")]
      public int DCP_Height
      {
         get{ return dCP_Height; }
         set{ dCP_Height = value; dCP_Height_IsChanged=true; }
      }
      public bool DCP_Height_IsChanged
      {
         get{ return dCP_Height_IsChanged; }
         set{ dCP_Height_IsChanged = value; }
      }
      private string dCP_PControl;
      private bool dCP_PControl_IsChanged=false;
      [MetaData("DCP_PControl","")]
      [StringLength(100, ErrorMessage = "长度不能超过100个字符")]
      public string DCP_PControl
      {
         get{ return dCP_PControl; }
         set{ dCP_PControl = value; dCP_PControl_IsChanged=true; }
      }
      public bool DCP_PControl_IsChanged
      {
         get{ return dCP_PControl_IsChanged; }
         set{ dCP_PControl_IsChanged = value; }
      }
      private string dCP_CControl;
      private bool dCP_CControl_IsChanged=false;
      [MetaData("DCP_CControl","")]
      [StringLength(100, ErrorMessage = "长度不能超过100个字符")]
      public string DCP_CControl
      {
         get{ return dCP_CControl; }
         set{ dCP_CControl = value; dCP_CControl_IsChanged=true; }
      }
      public bool DCP_CControl_IsChanged
      {
         get{ return dCP_CControl_IsChanged; }
         set{ dCP_CControl_IsChanged = value; }
      }
   }
}
