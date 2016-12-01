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
    pass


@route('/api/ReversedWords')
def reversed_words():
    pass


@route('/api/TriangleType')
def triangle_type():
    pass