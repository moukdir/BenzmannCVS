<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<ol id="selectable">
	<li class="ui-widget-content">Item 1</li>
	<li class="ui-widget-content">Item 2</li>
	<li class="ui-widget-content">Item 3</li>
	<li class="ui-widget-content">Item 4</li>
	<li class="ui-widget-content">Item 5</li>
	<li class="ui-widget-content">Item 6</li>
	<li class="ui-widget-content">Item 7</li>
</ol>
	<script type="text/javascript">
	$(function() {
		$("#selectable").selectable();
	});
	</script>
