$(function () {
    $("#master a").click(function () {
        $(this).addClass('active').siblings().removeClass('active');
    });
});
