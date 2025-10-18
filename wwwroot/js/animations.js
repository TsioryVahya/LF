// Animations au scroll avec Intersection Observer
document.addEventListener('DOMContentLoaded', function() {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver(function(entries) {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                // Récupérer tous les éléments animés dans le même conteneur parent
                const parent = entry.target.parentElement;
                const siblings = Array.from(parent.children).filter(child => 
                    child.classList.contains('fade-in-up') || 
                    child.classList.contains('fade-in-down') ||
                    child.classList.contains('fade-in-left') ||
                    child.classList.contains('fade-in-right') ||
                    child.classList.contains('fade-in')
                );

                // Si l'élément fait partie d'un groupe, animer avec délai
                if (siblings.length > 1 && siblings.includes(entry.target)) {
                    const index = siblings.indexOf(entry.target);
                    setTimeout(() => {
                        entry.target.classList.add('animate');
                    }, index * 300); // Délai de 300ms entre chaque élément
                } else {
                    // Animation immédiate pour les éléments seuls
                    entry.target.classList.add('animate');
                }
                
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);

    // Observer tous les éléments avec les classes d'animation
    const animatedElements = document.querySelectorAll(
        '.fade-in-up, .fade-in-down, .fade-in-left, .fade-in-right, .fade-in'
    );
    
    animatedElements.forEach(element => {
        observer.observe(element);
    });
});
