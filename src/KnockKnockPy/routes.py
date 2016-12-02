"""
Routes and views for the bottle application.
"""

from bottle import route, view, request, response
from datetime import datetime

@route('/')
@route('/home')
@view('index')
def home():
    """Renders the home page."""
    return dict(
        year=datetime.now().year
    )

@route('/contact')
@view('contact')
def contact():
    """Renders the contact page."""
    return dict(
        title='Contact',
        message='Your contact page.',
        year=datetime.now().year
    )

@route('/about')
@view('about')
def about():
    """Renders the about page."""
    return dict(
        title='About',
        message='Your application description page.',
        year=datetime.now().year
    )


@route('/api/Fibonacci')
def fibonacci():
    n_str = request.query.n
    response.content_type = "application/json"
    try: n = int(n_str)
    except ValueError:
        response.status = 400
        return
    a,b = 0,1
    for i in range(abs(n)):
        a,b = b, a+b
    if n<0 and n%2 ==0:
        return str(-a)
    else:
        return str(a)



from io import StringIO

@route('/api/ReverseWords')
def reverses_words():
    sentence = request.query.sentence
    response.content_type = "application/json"
    out_str = StringIO()
    temp_str = StringIO()
    for c in sentence:
        if not c.isspace():
            temp_str.write(c)
        else:
            word = temp_str.getvalue()
            out_str.write(word[::-1])
            out_str.write(c)
            temp_str = StringIO()
    word = temp_str.getvalue()
    out_str.write(word[::-1])
    return '"{0}"'.format(out_str.getvalue())


@route('/api/TriangleType')
def triangle_type():
    a_str,b_str,c_str = request.query.a,request.query.b,request.query.c
    response.content_type = "application/json"
    try: a,b,c = int(a_str),int(b_str),int(c_str)
    except ValueError:
        response.status = 400
    if a <= 0 or b <=0 or c <=0:
        return '"Error"'
    elif a - b >= c or b-c>=a or a-c>=b:
        return '"Error"'
    if a == b == c:
        return '"Equilateral"'
    elif a == b or b == c or c == a:
        return '"Isosceles"'
    else:
        return '"Scalene"'

@route('/api/Token')
def token():
    response.content_type = "application/json"
    return '"f0042d62-3ff2-44d0-81fe-5d1103647aee"'