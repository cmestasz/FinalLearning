from flask import Flask
from flask import request

app = Flask(__name__)


@app.route('/classData', methods=['GET', 'POST',])
def classData():
    course = request.form.get('course', 'Curso no definido')
    topic = request.form.get('topic', 'Tema no definido')
    return {
        "answer": f"Esta deberia ser la pagina uno.^^^Esta deberia ser la pagina dos.^^^Esta deberia ser la pagina tres.^^^Curso:{course}^^^Tema:{topic}"
    }