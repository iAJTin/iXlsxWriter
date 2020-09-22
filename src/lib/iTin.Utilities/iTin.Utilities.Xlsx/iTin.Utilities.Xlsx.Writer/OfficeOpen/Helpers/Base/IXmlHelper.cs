
namespace OfficeOpenXml.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    /// <summary>
    /// Defines a generic XML helper.
    /// </summary>
    internal interface IXmlHelper
    {
        IXmlHelper Instance { get; }

        XmlDocument XmlDocument { get; set; }



        /// <summary>
        /// Create a new attribute for this document.
        /// </summary>
        /// <param name="name">Attribute name.</param>
        /// <returns>
        /// <see cref="XmlAttribute"/> reference that contains a new attribute.
        /// </returns>
        XmlAttribute CreateAttribute(string name);

        /// <summary>
        /// Creates an element with the specified Prefix, and LocalName.
        /// </summary>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <returns>
        /// The new <see cref="XmlElement"/>.
        /// </returns>
        XmlElement CreateElement(string prefix, string localName);

        /// <summary>
        /// Creates an element with the specified Prefix, LocalName, and NamespaceURI.
        /// </summary>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <param name="namespaceUri">The namespace URI of the new element.</param>
        /// <returns>
        /// The new <see cref="XmlElement"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">If <paramref name="prefix"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="prefix"/> length is less than 1.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="localName"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="localName"/> length is less than 1.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="namespaceUri"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="namespaceUri"/> length is less than 1.</exception>
        XmlElement CreateElement(string prefix, string localName, string namespaceUri);

        /// <summary>
        /// Create or return an element with the specified name, and adds it to the document root node.
        /// </summary>
        /// <param name="name">The name of the new element.</param>
        /// <returns>
        /// Return if it already exists, else it is created and added to the root node.
        /// </returns>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> length is less than 1.</exception>
        XmlNode CreateOrDefaultAndAppendElementToNode(string name);

        /// <summary>
        /// Create or return an element with the specified Prefix and LocalName, and adds it to the document root node.
        /// </summary>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <returns>
        /// Return if it already exists, else it is created and added to the root node.
        /// </returns>
        XmlNode CreateOrDefaultAndAppendElementToNode(string prefix, string localName);

        /// <summary>
        /// Create or return an element with the specified Prefix, LocalName and NamespaceUri, and adds it to the document root node.
        /// </summary>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <param name="namespaceUri">The namespace URI of the new element.</param>
        /// <returns>
        /// The new <see cref="XmlNode"/>.
        /// </returns>
        XmlNode CreateOrDefaultAndAppendElementToNode(string prefix, string localName, string namespaceUri);

        /// <summary>
        /// Create or return an element with the specified name, and adds it to the document in the specified node.
        /// </summary>
        /// <param name="root">The root node of new element.</param>
        /// <param name="name">The name of the new element.</param>
        /// <returns>
        /// Return if it already exists, else it is created and added to the specified node.
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="root"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> length is less than 3.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> contains white spaces.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> has not correct format.</exception>
        XmlNode CreateOrDefaultAndAppendElementToNode(XmlNode root, string name);

        /// <summary>
        /// Create or return an element with the specified Prefix and LocalName, and adds it to the document in the specified node.
        /// </summary>
        /// <param name="root">The root node of new element.</param>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <returns>
        /// Return if it already exists, else it is created and added to the specified node.
        /// </returns>
        XmlNode CreateOrDefaultAndAppendElementToNode(XmlNode root, string prefix, string localName);

        /// <summary>
        /// Create or return an element with the specified Prefix, LocalName and NamespaceUri, and adds it to the document in the specified node.
        /// </summary>
        /// <param name="root">The root node of new element.</param>
        /// <param name="prefix">The prefix of the new element.</param>
        /// <param name="localName">The local name of the new element.</param>
        /// <param name="namespaceUri">The namespace URI of the new element.</param>
        /// <returns>
        /// The new <see cref="XmlNode"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="root"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="prefix"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="prefix"/> length is less than 1.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="localName"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="localName"/> length is less than 1.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="namespaceUri"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="namespaceUri"/> length is less than 1.</exception>
        XmlNode CreateOrDefaultAndAppendElementToNode(XmlNode root, string prefix, string localName, string namespaceUri);

        /// <summary>
        /// Returns an reference than containing a list of all descendant elements that match the specified name.
        /// </summary>
        /// <param name="name">The qualified name to match. It is matched against the <b>Name</b> property of the matching node. The special value "*" matches all tags.</param>
        /// <returns>
        /// A list of all matching nodes. If no nodes match name, the returned collection will be empty.
        /// </returns>
        IEnumerable<XmlNode> GetElementsByTagName(string name);

        /// <summary>
        /// Selects the first <see cref="XmlNode"/> that matches the XPath expression in root node.
        /// </summary>
        /// <param name="path">XPath expression.</param>
        /// <returns>
        /// The first <see cref="XmlNode"/> that matches the XPath query or <b>null</b> if no matching node is found.
        /// </returns>
        XmlNode GetXmlNode(string path);

        /// <summary>
        /// Selects the first <see cref="XmlNode"/> that matches the XPath expression in the specified node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <param name="path">XPath expression.</param>
        /// <returns>
        /// The first <see cref="XmlNode"/> that matches the XPath query or <b>null</b> if no matching node is found.
        /// </returns>
        XmlNode GetXmlNode(XmlNode root, string path);

        /// <summary>
        /// Determines whether the specified element exist in the root node.
        /// </summary>
        /// <param name="name">The element name.</param>
        /// <returns>
        /// <b>true</b> if exist; otherwise, <b>false</b>.
        /// </returns>
        bool HasElement(string name);

        /// <summary>
        /// Determines whether the specified element exist in the specified node.
        /// </summary>
        /// <param name="root">The root node.</param>
        /// <param name="name">The element name.</param>
        /// <returns>
        /// <b>true</b> if exist; otherwise, <b>false</b>.
        /// </returns>
        bool HasElement(XmlNode root, string name);

        /// <summary>
        /// Try to get the item in the specified node if exist is returned in the parameter <paramref name="node"/>, otherwise will contain <b>null</b>, if the operation is performed returns <b>true</b>.
        /// </summary>
        /// <param name="root">The root node of new element.</param>
        /// <param name="name">The element name.</param>
        /// <param name="node">The output node.</param>
        /// <returns>
        /// <b>true</b> if exist; otherwise, <b>false</b>.
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="root"/> is <b>null</b>.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> is empty.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> length is less than 3.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> contains white spaces.</exception>
        /// <exception cref="InvalidOperationException">If <paramref name="name"/> has not correct format.</exception>
        bool TryGetElementFrom(XmlNode root, string name, out XmlNode node);
    }
}
