namespace AnteyaVIP.Web.Infrastructure.HtmlHelpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHelpers
    {

        public static WindowBuilder FullFeaturedPopUpWindow(this HtmlHelper helper, 
            string windowName, 
            string windowTitle,
            bool visible = false,
            bool modal = true, 
            bool draggable = true, int width = 500)
        {
            return helper.Kendo().Window().Name(windowName)
                        .Title(windowTitle)
                        .Visible(visible)
                        .Modal(modal)        
                        .Iframe(true)
                        .Draggable(draggable)
                        .Width(width);
        }


        public static DropDownListBuilder FullFeaturedDropDownList<T>(this HtmlHelper<T> helper, Expression<Func<T, T>> expression, string textField, string valueField, string controllerName)
        {
            return helper.Kendo().DropDownListFor(expression)
                .AutoBind(false)
                .OptionLabel("Select...")
                .DataTextField(textField)
                .DataValueField(valueField)
                .DataSource(dataSource =>
                {
                    dataSource.Read(read => read.Action("GetDropDownListData", controllerName))
                            .ServerFiltering(true);
                });  
        }

        public static GridBuilder<T> FullFeaturedGrid<T>(this HtmlHelper helper, Expression<Func<T, object>> modelIdExpression, string controllerName, Action<GridColumnFactory<T>> columns = null, object routeValues = null) where T : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(c => c.Edit());
                    cols.Command(c => c.Destroy());
                };
            }

            return helper.Kendo()
                .Grid<T>()
                .Name("grid")
                .Columns(columns)
                .ColumnMenu()
                .Pageable(page => page.Refresh(true))
                .Sortable()
                .Groupable()
                .Filterable()
                .Editable(edit => edit.Mode(GridEditMode.PopUp))
                .ToolBar(toolbar => toolbar.Create())
                .DataSource(data =>
                    data
                        .Ajax()
                        .Model(m => m.Id(modelIdExpression))
                        .Read(read => read.Action("Read", controllerName, routeValues))
                        .Create(create => create.Action("Create", controllerName, routeValues))
                        .Update(update => update.Action("Update", controllerName))
                        .Destroy(destroy => destroy.Action("Destroy", controllerName))
                        );
        }
    }
}