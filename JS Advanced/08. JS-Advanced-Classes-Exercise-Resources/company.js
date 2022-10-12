function company(){
class Company {
        constructor(){
            this.departments = new Map();
        }
    
    
        addEmployee(name, salary, position, department){
            
            if(!name || !salary || salary < 0 || !position || !department){
                throw new Error('Invalid input!');
            }
           
            if(!this.departments.has(department)){
                this.departments.set(department, [])
            }

            this.departments.get(department).push({name, salary: Number(salary), position, department});

            return `New employee is hired. Name: ${name}. Position: ${position}`;
        }

        bestDepartment(){
            let highestAverageSalary = 0;
            let bestDepartment = '';

            for(let [department, employees] of this.departments){
                let currentAverageSalary = employees
                .map(e => e.salary)
                .reduce((a, b) => a + b, 0) / employees.length;

                if(currentAverageSalary > highestAverageSalary){
                    highestAverageSalary = currentAverageSalary;
                    bestDepartment = department;
                }
            }

            let employees = this.departments.get(bestDepartment).sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name));
            
            let result = `Best Department is: ${bestDepartment}\nAverage salary: ${highestAverageSalary.toFixed(2)}\n`;

            employees.forEach(e => {
                result += `${e.name} ${e.salary} ${e.position}\n`;
            })

            return result.trim();
            
        }
    }

    let c = new Company();
    c.addEmployee("Stanimir", 2000, "engineer", "Construction");
    c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
    c.addEmployee("Slavi", 500, "dyer", "Construction");
    c.addEmployee("Stan", 2000, "architect", "Construction");
    c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
    c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
    c.addEmployee("Gosho", 1350, "HR", "Human resources");

    let bestDepartment = c.bestDepartment();
    return bestDepartment;

}

console.log(company());
