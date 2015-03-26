$(function () {
    var grid = new Grid();
    grid.init();

    $(".grid-multiselect").multiSelect({
        selectableHeader: "<div class='custom-header'>Не выбранные</div>",
        selectionHeader: "<div class='custom-header'>Выбранные</div>",
    });
})