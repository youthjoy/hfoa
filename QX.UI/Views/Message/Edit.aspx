﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BasePage.Master" Inherits="System.Web.Mvc.ViewPage<QX.Model.Bse_Message>" %>

<%@ Import Namespace="QX.HtmlHelperLib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Eidt
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="FileInfo" method='post' action="/Message/FileOperation">
    <fieldset class="DocmentsWidth">
        <legend>信息维护</legend>
        <input type="hidden" id="formOper" value="edit" name="formOper" />
        <input type="hidden" id="optype" value="nor" name="optype" />
        <%=Html.AutoBindForm<QX.Model.Bse_Message>("Bse_MessageModule", "Bse_Message",Model,false,false,false)%>
    </form>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">正文</a></li>
         
            <li><a href="#tabs-3">分发</a></li>
        </ul>
        <div id="tabs-1">
            <%Html.RenderPartial("FCKEditor",Model.Msg_Content!=null?Model.Msg_Content:""); %>
        </div>
        
        <div id="tabs-3">
            <%=Html.GenToolbarHelper("Doc_AllotModule", "Doc_Allot", "addN:'分发',addFunJs:'Allot()'")%>
            <%=Html.SysComm_JqGrid("Doc_AllotModule", "Doc_Allot", "/Doc/GetAllot/"+Model.Msg_Code, true)%>
        </div>
    </div>
    <div class="FormToolBar">
        
        <input type='button' name='button' value='提交' onclick='Message_Operation.SaveData()' />
        <input type='button' name='cancle' value='返回' onclick='ComOperation.CancelEdit()' />
    </div>
    <%=Html.AutoBindValidate("Bse_MessageModule", "FileInfo")%>
    </fieldset>

    <script type="text/javascript">

        function GetbackUrl() {
            var backUrl = '<%=ViewData["backUrl"]%>';
            return backUrl;
        }

        function Doc_AllotAllot() {

        }

       
        $(document).ready(function() {


            //            $("#example").multiselect({
            //                checkAllText: "全选",
            //                unCheckAllText: "不选",
            //                selectedList: 100 // 0-based index
            //            });

            Common_EmpTree_DialogDept.Init("Doc_Allot_add", function(code, name) {
                //                for (var p in array) {
                //                    alert(array[p][0]);
                //                }
                //人员回写
                $.ajax({
                    type: "post",
                    url: "/Doc/DocAllot",
                    dataType: "json",
                    data: { code: code.join(','), name: name.join(','), doc: $("#Doc_Code").val(), module: 'Bse_FileModule' },
                    success: function(re, textStatus) {
                        //                $("#Doc_Attachmentgrid").trigger("reloadGrid");
                        $("#Doc_Allotgrid").trigger("reloadGrid");
                    }
                });
            });
            Message_Operation.Init();
            $("#tabs").tabs();

            //$("#Doc_Allotgrid").setGridParam({ url: '/Doc/GetAllot/' + $("#Doc_Code").val() }).trigger("reloadGrid");

            // Doc_Allot_Doc_AllotModule_GridControl.Init('/Doc/GetAllot/'+$("#Doc_Code").val(),"Doc_Allot");
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderExtend" runat="server">
    <link href="/Content/css/jquery.multiselect.css" rel="stylesheet" type="text/css" />

    <script src="/Scripts/Shared/jquery.multiselect.min.js" type="text/javascript"></script>

    <script src="/Scripts/Shared/Dict.js" type="text/javascript"></script>

    <script src="/Scripts/Shared/Dept.js" type="text/javascript"></script>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="TopMenu" runat="server">
</asp:Content>
