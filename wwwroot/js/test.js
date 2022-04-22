
function refreshKb4Graphs()
{
    refreshPhishScoreByDepartment();
    refreshPhishScoreOverTime();
}

function DestroyOldChart(chartName)
{
    oldChart = Chart.getChart(chartName)
    if (oldChart)
    {
        console.log("Destroying ", chartName);
        oldChart.destroy();
    }
}

function refreshPhishScoreOverTime()
{
    DestroyOldChart('canvasPhishScoreOverTime');
    const ctx = document.getElementById("canvasPhishScoreOverTime").getContext("2d");

    var canvasPhishScoreOverTime = new Chart(ctx, {
        type: 'line',
        data: {
          labels: ["10/2021", "11/2021", "12/2021", "01/2022", "02/2022", "03/2022", "04/2022"],
          datasets: [{ 
              data: [86,114,106,106,107,111,133],
              label: "Total",
              borderColor: "rgb(62,149,205)",
              backgroundColor: "rgb(62,149,205,0.1)",
            }, { 
              data: [70,90,44,60,83,90,100],
              label: "Customer Service",
              borderColor: "rgb(60,186,159)",
              backgroundColor: "rgb(60,186,159,0.1)",
            }, { 
              data: [10,21,60,44,17,21,17],
              label: "Data Entry",
              borderColor: "rgb(255,165,0)",
              backgroundColor:"rgb(255,165,0,0.1)",
            }, { 
              data: [6,3,2,2,7,0,16],
              label: "Partner Services",
              borderColor: "rgb(196,88,80)",
              backgroundColor:"rgb(196,88,80,0.1)",
            }
          ]
        },
      });
}

function refreshPhishScoreByDepartment()
{
    DestroyOldChart('canvasPhishScoreByDepartment');
    const ctx = document.getElementById("canvasPhishScoreByDepartment").getContext("2d");

    const canvasPhishScoreByDepartment = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Customer Service', 'Partner Services', 'Data Entry', 'IS', 'Warehouse', 'IT'],
            datasets: [{
                label: 'Phish Score',
                data: [12, 19, 3, 5, 2, 3],
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}
