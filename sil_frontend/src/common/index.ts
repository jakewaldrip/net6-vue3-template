const Sleep = (ms: number) => {
    return new Promise(resolve => setTimeout(resolve, ms));
}

export {
    Sleep
}