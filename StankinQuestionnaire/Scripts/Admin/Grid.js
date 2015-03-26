function Grid() {
    var that = this;
    var selectors = {
        addForm: "#add-form",
        btnAdd: "#btnAdd",
        btnCancel: "#btnCancel",
        grid: "#grid",
        btnEdit: ".btnEdit",
        btnSaveEdit: "#btnSaveEdit",
        editForm: "#edit-form",
        errorAlert: "#error-alert",
        errorText: "#error-text",
        btnDelete: ".btnDelete",
        deleteForm: "#delete-form",
        btnConfirmDelete: "#btnConfirmDelete",
        statusContainer: "#status-container",
    }

    var allowSelect = new Array();

    var controlTypes = {
        SELECT: "select",
        INPUT: "input"
    }

    var selectItem = function (text, value) {
        this.value = value;
        this.text = text;
    }

    var templates = {
        status: '<div class="alert alert-success alert-dismissible" role="alert">\
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>\
                    <span id="status-text"></span>\
                </div>',
        optionSelected: '<option selected="selected" value="%1">%2</option>',
        optionUnselected: '<option value="%1">%2</option>'
    }

    var dataAttr = {
        editUrl: "data-grid-setting-edit-url",
        indicator: "data-grid-indicator",
        indicators: "data-grid-indicators",
        key: "data-grid-key",
        keyFormValue: "data-grid-key-value",
        deleteUrl: "data-grid-setting-delete-url"
    }

    var settings = {
        editUrl: "",
        indicators: new Array(),
        keyProperty: "ID",
        deleteUrl: ""
    }

    var currentLadda;

    Array.prototype.find = function (searchElement, property) {
        var returnValue = null;
        if (property) {
            this.forEach(function (element, index) {
                if (element[property] === searchElement) {
                    returnValue = index;
                }
            });
        }
        else {
            this.forEach(function (element, index) {
                if (element === searchElement) {
                    returnValue = index;
                }
            });
        }
        return returnValue;
    }

    this.init = function () {
        (function btnActinonsBind() {
            $(selectors.btnAdd).mousedown(that.btnAdd);
            $(selectors.btnCancel).mousedown(that.btnCancelAdd);
            $(selectors.btnEdit).mousedown(that.btnEdit);
            $(selectors.btnSaveEdit).mousedown(that.btnSaveEdit);
            $(selectors.btnDelete).mousedown(that.btnDelete);
            $(selectors.btnConfirmDelete).mousedown(that.btnConfirmDelete);
        })();

        (function settingsInit() {
            settings.editUrl = $(selectors.grid).attr(dataAttr.editUrl);
            settings.deleteUrl = $(selectors.grid).attr(dataAttr.deleteUrl);
            settings.indicators = $(selectors.grid).attr(dataAttr.indicators).split(",");
        })();

        $(selectors.addForm + " select>option").each(function () {
            addAllowSelect($(this).html(), $(this).val());
        });


        Ladda.bind(selectors.btnSaveEdit);
        $(selectors.editForm).on("hidden.bs.modal", function () {
            endLadda();
        });
    }

    this.btnAdd = function () {
        $(selectors.addForm).show();
    }
    this.btnCancelAdd = function () {
        $(selectors.addForm).hide();
    }
    this.btnEdit = function () {
        var currentBtn = this;
        var currentTr = findTrByBtn(currentBtn);
        fillEditForm(currentTr);
    }
    this.btnSaveEdit = function () {
        var ladda = Ladda.create(this);
        currentLadda = ladda;
        ladda.start();
        var data = $(selectors.editForm + " input").serialize();
        var selectData = $(selectors.editForm + " select").serialize();
        var key = $(selectors.editForm).attr(dataAttr.keyFormValue);
        data = data + "&" + selectData + "&ID=" + key;
        $.ajax({
            url: settings.editUrl,
            data: data,
            method: "POST"
        })
        .always(function () {
            ladda.stop();
        })
        .done(function (data) {
            if (data.Status === 1) {
                var currentID = data.Entity[settings.keyProperty];
                var currentTr = findTrByID(currentID);
                for (var property in data.Entity) {
                    if (property.toString() != settings.keyProperty) {
                        var currentTd = findTdByIndicator(currentTr, property.toLowerCase());
                        var selectList = currentTd.find("select");
                        if (selectList.length > 0) {//Для select
                            if (data.Entity[property] != null) {
                                selectList.find("option").each(function (index, value) {//по всем выбранным ранее
                                    var element = data.Entity[property].find(parseInt($(value).val()));//элемент есть в выделенных
                                    if (element == null) {
                                        addAllowSelect($(value).html(), $(value).val());
                                        $(value).remove();
                                    }
                                });
                                allowSelect.forEach(function (value, index) {//по не выбранным
                                    var element = data.Entity[property].find(value.value);
                                    if (element != null) {
                                        selectList.html(selectList.html() + templates.optionSelected
                                            .replace(/%1/, value.value)
                                            .replace(/%2/, value.text));
                                        removeAllowSelect(element);
                                    }
                                });
                            }
                            else {
                                selectList.find("option").each(function (index, value) {//по всем выбранным ранее
                                    addAllowSelect($(value).html(), $(value).val());
                                    $(value).remove();
                                });
                            }
                        }
                        else {
                            currentTd.html(data.Entity[property]);
                        }
                    }
                }
                $(selectors.editForm).modal('hide');
                showAlert(data.Text);
            }
            else {
                showModalError(data.Text);
            }
        })
        .fail(function () {
            showModalError("На сервере произошла ошибка!");
        })
    }
    this.btnDelete = function () {
        var currentBtn = this;
        var currentTr = findTrByBtn(currentBtn);
        fillDeleteForm(currentTr);
    }
    this.btnConfirmDelete = function () {
        var key = $(selectors.deleteForm).attr(dataAttr.keyFormValue);
        $.ajax({
            url: settings.deleteUrl,
            data: "ID=" + key,
            method: "POST"
        })
        .always(function () { })
        .done(function (data) {
            if (data.Status === 1) {
                var key = data[settings.keyProperty];
                var currentTr = findTrByID(key);
                currentTr.remove();
                $(selectors.deleteForm).modal('hide');
                showAlert(data.Text);
            }
            else {
                showModalError(data.Text);
            }
        })
        .fail(function () {
            showModalError("На сервере произошла ошибка!");
        })
    }

    function showAlert(text) {
        $(selectors.statusContainer).html(text);
        $(selectors.statusContainer).show();
    }
    function showModalError(text) {
        $(selectors.errorAlert).show();
        $(selectors.errorText).html(text);
    }

    function fillEditForm(currentTr) {
        for (var i = 0; i < settings.indicators.length; i++) {//
            var input = searchInput(settings.indicators[i]);
            switch ($(input)[0].tagName.toLowerCase()) {
                case controlTypes.SELECT:
                    var currentTd = findTdByIndicator(currentTr, settings.indicators[i]);
                    var currentSelectedOptions = getSelctedOptions(currentTd);
                    var currentUnselectedOptions = getUnselctedOptions();
                    var value = currentSelectedOptions + currentUnselectedOptions;
                    input.html(value);
                    $(input).multiSelect('refresh');
                    break;
                case controlTypes.INPUT:
                    var value = searchData(currentTr, settings.indicators[i]);
                    input.val(value);
                    break;
            }
            var key = $(currentTr).attr(dataAttr.key);
            $(selectors.editForm).attr(dataAttr.keyFormValue, key);
        }
    }
    function fillDeleteForm(currentTr) {
        var key = $(currentTr).attr(dataAttr.key);
        $(selectors.deleteForm).attr(dataAttr.keyFormValue, key);
    }

    function searchData(tr, indicator) {
        return findTdByIndicator(tr, indicator).html();
    }
    function findTdByIndicator(currentTr, indicator) {
        return $(currentTr).find("td[" + dataAttr.indicator + "='" + indicator + "']");
    }
    function searchInput(indicator) {
        return $(selectors.editForm).find("[" + dataAttr.indicator + "='" + indicator + "']");
    }

    function endLadda() {
        if (currentLadda) {
            currentLadda.stop();
        }
    }

    function findTrByBtn(btn) {
        return $(btn).parents("tr:first");
    }
    function findTrByID(id) {
        return $(selectors.grid).find("tr[" + dataAttr.key + "='" + id + "']");
    }
    function getUnselctedOptions() {
        var options = "";
        allowSelect.forEach(function (element, index) {
            var option = templates.optionUnselected
                .replace(/%1/, element.value)
                .replace(/%2/, element.text);
            options = options + option;
        });
        return options;
    }
    function getSelctedOptions(currentTd) {
        var options = "";
        $(currentTd).find("select>option:selected").each(function () {
            var option = templates.optionSelected
              .replace(/%1/, $(this).val())
              .replace(/%2/, $(this).html());
            options = options + option;
        })
        return options;
    }

    function removeAllowSelect(element) {
        allowSelect.splice(allowSelect.find(element, "value"), 1);
    }
    function addAllowSelect(text, value) {
        allowSelect.push(new selectItem(text,parseInt(value)));
    }

}
