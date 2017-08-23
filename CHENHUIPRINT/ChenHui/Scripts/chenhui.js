(function ($) {
    $.fn.serializeObject = function () {
        var obj = {};
        $(this.serializeArray()).each(function () {
            obj[this.name] = this.value;
        });
        return obj;
    };
})(jQuery);
function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}
function Guid() {
    return (S4() + S4() + "" + S4() + "" + S4() + "" + S4() + "" + S4() + S4() + S4());
}