from flask import Flask
from flask import request

app = Flask(__name__)


@app.route('/classData', methods=['GET', 'POST',])
def classData():
    course = request.form.get('course', 'Curso no definido')
    topicName = request.form.get('topicName', 'Tema no definido')
    topicDescription = request.form.get('topicDescription', 'Descripcion no definida')
    return {
        "answer": f"Esta deberia ser la pagina uno.^^^Esta deberia ser la pagina dos.^^^Esta deberia ser la pagina tres.^^^Curso:{course}^^^Tema:{topicName}^^^Descripcion:{topicDescription}"
    }


@app.route('/question', methods=['GET', 'POST',])
def question():
    question = request.form.get('question', 'Pregunta no definida')
    return {
        "answer": f"Respuesta a la pregunta '{question}'"
    }