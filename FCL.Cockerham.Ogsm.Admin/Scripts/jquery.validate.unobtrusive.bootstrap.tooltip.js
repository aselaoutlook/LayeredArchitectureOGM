﻿(function ($) {
	var classes = { groupIdentifier: ".form-group", error: 'has-error', success: null };//success: 'has-success' 
	function updateClasses(inputElement, toAdd, toRemove) {
		var group = inputElement.closest(classes.groupIdentifier);
		if (group.length > 0) {
			group.addClass(toAdd).removeClass(toRemove);
		}
	}
	function onError(inputElement, message) {
		updateClasses(inputElement, classes.error, classes.success);
		var options = { html: true, animation:false, placement: 'top', template: '<div class="tooltip-error" role="tooltip"><div class="tooltip-error tooltip-arrow"></div><div class="tooltip-inner"></div></div>', title: message};
	    inputElement.tooltip("destroy").addClass("error").tooltip(options);
	}
	function onSuccess(inputElement) {
		updateClasses(inputElement, classes.success, classes.error);
		inputElement.tooltip("destroy");
	}

	function onValidated(errorMap, errorList) {
		$.each(errorList, function () {
			onError($(this.element), this.message);
		});

		if (this.settings.success) {
			$.each(this.successList, function () {
				onSuccess($(this));
			});
		}
	}

	$(function () {
		$('form').each(function () {
			var validator = $(this).data('validator');
			validator.settings.showErrors = onValidated;
		});
	});
}(jQuery));


