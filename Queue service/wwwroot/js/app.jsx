class Task extends React.Component{
 
    constructor(props){
        super(props);
        this.state = {data: props.task};
    }
    render(){
        return <div>
                <p><b>{this.state.data.name}</b></p>
                <p>Описание задачи {this.state.data.description}</p>
                <p> Выполнено {this.state.data.isDone}</p>
        </div>;
    }
}
 
class TaskForm extends React.Component{
 
    constructor(props){
        super(props);
        this.state = {name: "", description:"", isDone: false};
 
        this.onSubmit = this.onSubmit.bind(this);
        this.onNameChange = this.onNameChange.bind(this);
        this.onDescriptionChange = this.onDescriptionChange.bind(this);
        this.onReadyChange = this.onReadyChange.bind(this);
    }
    onNameChange(e) {
        this.setState({name: e.target.value});
    }
    onDescriptionChange(e) {
        this.setState({description: e.target.value});
    }
    onReadyChange(e) {
        this.setState({isDone: e.target.value});
    }
    onSubmit(e) {
        e.preventDefault();
        var name = this.state.name.trim();
        var description = this.state.description;
        var isDone = this.state.isDone;
        if (!name || !description) {

            var xml="<?xml version='1.0' encoding='utf-8'?><!DOCTYPE recipe> <type>" + name + " </type><description> " + description + " </description><isdone> " + isDone + "</isdone></type>";
            var xhr = new XMLHttpRequest();             
            xhr.open("post", this.props.apiUrl, true);
            xhr.setRequestHeader("Content-type", "application/json");
            xhr.send(xml);
        }
        this.props.onTaskSubmit({ name: name, description: description, isDone: isDone});
        this.setState({name: "", description:"", isDone:false});
    }
    render() {
        return (
          <form onSubmit={this.onSubmit}>
              <p>
  <select className="form-control" value={this.state.name}
                         onChange={this.onNameChange}> 
      <option>Куда сходить?</option> 
      <option>Задачи для дома</option> 
      <option>Дела по учебе</option>  
    </select> 
              
              </p>
            <p>
    <textarea id="description" className="form-control" value={this.state.description}
                       onChange={this.onDescriptionChange}  rows="3"></textarea> 
            </p>
             <p>
    <input id="checkbox" type="checkbox" value={this.state.isDone}
                         onChange={this.onReadyChange}  className="form-check-input" /> 
              </p>
            <input type="submit" value="Сохранить" />
          </form>
        );
    }
}
 
 
class TasksList extends React.Component{
 
    constructor(props){
        super(props);
        this.state = { tasks: [] };
 
        this.onAddTask = this.onAddTask.bind(this);
        this.onRemoveTask = this.onRemoveTask.bind(this);
    }
    // загрузка данных
    loadData() {
        var xhr = new XMLHttpRequest();
    }
    componentDidMount() {
        this.loadData();
    }
    // добавление объекта
    onAddTask(task) {
        if (task) {
 
            var data = JSON.stringify({"name":task.name, "description":task.description, "isDone": task.isDone});
            var xhr = new XMLHttpRequest();            
            xhr.open("post", this.props.apiUrl, true);
            xhr.setRequestHeader("Content-type", "application/json");
            xhr.onload = function () {
                if (xhr.status == 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    // удаление объекта
    onRemoveTask(task) {
 
        if (task) {
            var url = this.props.apiUrl + "/" + task.id;
             
            var xhr = new XMLHttpRequest();
            xhr.open("delete", url, true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (xhr.status == 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send();
        }
    }
    render(){
 
        var remove = this.onRemoveTask;
        return <div>
                <TaskForm onTaskSubmit={this.onAddTask} />
                <h2>Список задач</h2>
        </div>;
    }
}
 
ReactDOM.render(
  <TasksList apiUrl="/api/values" />,
  document.getElementById("content")
);