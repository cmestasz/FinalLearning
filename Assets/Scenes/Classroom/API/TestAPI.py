from flask import Flask
from flask import request

app = Flask(__name__)


@app.route('/classData', methods=['GET', 'POST',])
def classData():
    course = request.form.get('course', 'Curso no definido')
    topicName = request.form.get('topicName', 'Tema no definido')
    topicDescription = request.form.get(
        'topicDescription', 'Descripcion no definida')
    return {
        "pages": [
            f"Curso:{course}",
            f"Tema:{topicName}",
            f"Descripcion:{topicDescription}",
            "Pagina de prueba",
            "Pagina de prueba",
            "Pagina de prueba"
        ]
    }


@app.route('/question', methods=['GET', 'POST',])
def question():
    question = request.form.get('question', 'Pregunta no definida')
    return {
        "answer": f"Respuesta a la pregunta '{question}'"
    }


@app.route('/testquestions', methods=['GET', 'POST',])
def testquestions():
    return {
        "questions": [
            "Pregunta 1",
            "Pregunta 2",
            "Pregunta 3",
            "Pregunta 4",
            "Pregunta 5",
            "Pregunta 6",
            "Pregunta 7",
            "Pregunta 8",
            "Pregunta 9",
            "Pregunta 10"
        ]
    }


@app.route('/testanswers', methods=['GET', 'POST',])
def testanswers():
    return {
        "results": [
            1,
            0,
            0,
            1,
            1,
            1,
            1,
            1,
            0,
            1
        ],
        "correct": [
            "Respuesta 1",
            "Respuesta 2",
            "Respuesta 3",
            "Respuesta 4",
            "Respuesta 5",
            "Respuesta 6",
            "Respuesta 7",
            "Respuesta 8",
            "Respuesta 9",
            "Respuesta 10"
        ]
    }