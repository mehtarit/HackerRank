using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    class DoublyLinkedListNode {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData) {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    class DoublyLinkedList {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList() {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData) {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null) {
                this.head = node;
            } else {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep, TextWriter textWriter) {
        while (node != null) {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null) {
                textWriter.Write(sep);
            }
        }
    }

    // Complete the sortedInsert function below.

    /*
     * For your reference:
     *
     * DoublyLinkedListNode {
     *     int data;
     *     DoublyLinkedListNode next;
     *     DoublyLinkedListNode prev;
     * }
     *
     */
    static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data) {

        var nodeToInsert = new DoublyLinkedListNode(data);

        if(head == null){
            return nodeToInsert;
        }
        
        var result = head;

        while(head.next != null && head.data <= nodeToInsert.data){
            head = head.next;
        }

        if(head.prev == null){
            head.prev = nodeToInsert;
            nodeToInsert.next = head;
            return nodeToInsert;
        }

        if(head.next == null){
            if(head.data <= nodeToInsert.data){
                head.next = nodeToInsert;
                nodeToInsert.prev = head;
                return result;
            }
        }
        
        head.prev.next = nodeToInsert;
        nodeToInsert.prev = head.prev;
        head.prev = nodeToInsert;
        nodeToInsert.next = head;
        return result;
    }

    static void Main(string[] args) {
