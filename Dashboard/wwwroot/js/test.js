
/**
 * DestroyOldChart
 * 
 * Given the name of a chart, destroy it so that it can be recreated
 * @param {string} chartName
 */
function DestroyOldChart(chartName)
{
    oldChart = Chart.getChart(chartName)
    if (oldChart)
    {
        console.log("Destroying ", chartName);
        oldChart.destroy();
    }
}


/**
 * Setup
 * 
 * Recreates a chart by this id with the given config
 * @param {any} id
 * @param {any} config
 */
window.setup = (id, config) => {
    DestroyOldChart(id);
    var ctx = document.getElementById(id).getContext('2d');
    new Chart(ctx, config);
}