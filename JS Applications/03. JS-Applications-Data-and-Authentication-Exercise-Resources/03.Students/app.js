const button = document.getElementById('submit');
const tBody = document.querySelector('tbody');
const [firstName, lastName, facultyNumber, grade] = document.getElementsByClassName('inputs')[0].children;

const url = 'http://localhost:3030/jsonstore/collections/students/';

function solution(){
    button.addEventListener('click', async () =>{
        await fetch(url, {
            method: 'POST',
            headers:{
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                firstName: firstName.value,
                lastName: lastName.value,
                facultyNumber: facultyNumber.value,
                grade: grade.value
            })
        })      
    });
    loadStudents();
}

async function loadStudents(){
    const response = await fetch(url);
    const data = Object.values(await response.json());

    data.forEach(s => {
        const trStudent = document.createElement('tr');

        const tdFirstName = document.createElement('td');
        tdFirstName.textContent = s.firstName;
        trStudent.appendChild(tdFirstName);

        const tdLastName = document.createElement('td');
        tdLastName.textContent = s.lastName;
        trStudent.appendChild(tdLastName);
        
        const tdFacultyNumber = document.createElement('td');
        tdFacultyNumber.textContent = s.facultyNumber;
        trStudent.appendChild(tdFacultyNumber);

        const tdGrade = document.createElement('td');
        tdGrade.textContent = s.grade;
        trStudent.appendChild(tdGrade);

        tBody.appendChild(trStudent);

    })
}

solution();