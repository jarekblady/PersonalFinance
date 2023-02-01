import React from 'react'
import { Pie } from "react-chartjs-2";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js'

ChartJS.register(ArcElement, Tooltip, Legend);

function Chart({ labels, data }) {

    const chartData = {
        labels: labels,
        datasets: [
            {
                data: data,
                backgroundColor: [
                    'rgb(255, 159, 64)',
                    'rgb(255, 205, 86)',
                    'rgb(75, 192, 192)',
                    'rgb(54, 162, 235)',
                    'rgb(153, 102, 255)',
                    'rgb(201, 203, 207)',
                    'rgb(50, 52, 168)',
                    'rgb(10, 240, 10)',
                    'rgb(255, 99, 132)',
                    'rgb(255, 159, 64)',
                    'rgb(255, 205, 86)',
                    'rgb(75, 192, 192)',
                    'rgb(54, 162, 235)'
                ],
                borderColor: "black",
                borderWidth: 2,
            }
        ],
    };

    return <Pie data={chartData} />;
}

export default Chart;