layui.config({
    base: '/lib/xadmin/lib/layui/module/'
}).extend({
    treeSelect: 'treeSelect',
    treetable: 'treetable-lay/treetable'
}).use(['treetable'], function () {
    var treetable = layui.treetable;
});;