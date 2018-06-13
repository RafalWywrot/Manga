$(function () {
    SetUpMultiSelectChoice()
    function SetUpMultiSelectChoice() {
        $('.multiSelect').multiselect(
            {
                enableCaseInsensitiveFiltering: true,
                filterPlaceholder: 'Find',
                numberDisplayed: 1,
                maxHeight: 350
            });
    };

})(jQuery);